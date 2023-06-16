using Cluu;
using Cluu.Backbone;
using Cluu.Client;
using Cluu.Security.Authentication;
using Cluu.Threading;
using Microsoft.Identity.Client;
using WinFormsCluuDemo.Services.Identity;

namespace WinFormsCluuDemo.Services.Login;

internal partial class SingleSignOnLoginService
{
    private class IdentityProvider : IWinFormsIdentityProviderInternal
    {
        private readonly ICluuAuthenticationProvider cluuAuthenticationProvider;
        private readonly CluuAsyncLazyCacheValue<ICluuIdentity> identityLoader;

        public IdentityProvider(ICluuAuthenticationProvider cluuAuthenticationProvider)
        {
            this.cluuAuthenticationProvider = cluuAuthenticationProvider;

            this.identityLoader = new CluuAsyncLazyCacheValue<ICluuIdentity>(TimeSpan.FromHours(12), this.CreateCluuIdentity);
        }

        async Task<ICluuIdentity> IWinFormsIdentityProviderInternal.GetIdentityAsync(CancellationToken cancellationToken)
        {
            return await this.identityLoader.GetValueAsync(cancellationToken).ConfigureAwait(false);
        }

        internal async Task<ICluuIdentity> LoginInternalAsync(CancellationToken cancellationToken)
        {
            var app = PublicClientApplicationBuilder.CreateWithApplicationOptions(
                new PublicClientApplicationOptions
                {
                    ClientId = "26d9527d-0f57-427d-a5ca-51aa7a45e94e",
                    TenantId = "bf4f8299-b53b-4d37-b22c-2cce7dea76c3",
                }
            ).Build();

            // Problem bei Erstellen des SSO-Login-Dialogs, wenn im STA-Thread aufgerufen. Task.Run
            // nutzt einen ThreadPool-Thread.
            string idToken = await Task.Run(async () =>
            {
                var token = await app
                    .AcquireTokenInteractive(new string[] { "openid" })
                    .ExecuteAsync(cancellationToken)
                    .ConfigureAwait(false);

                return token.IdToken;
            }).ConfigureAwait(false);

            return await this.cluuAuthenticationProvider.AuthenticateAsync(
                null,
                idToken,
                nameof(CluuDefaultAuthenticationMethod.IssuedToken),
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async ValueTask<ICluuIdentity> CreateCluuIdentity(CancellationToken cancellationToken)
        {
            return await this.LoginInternalAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
