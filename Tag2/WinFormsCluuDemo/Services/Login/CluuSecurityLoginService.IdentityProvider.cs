using Cluu;
using Cluu.Security.Authentication;
using Cluu.Threading;
using WinFormsCluuDemo.Services.Identity;

namespace WinFormsCluuDemo.Services.Login;

internal partial class CluuSecurityLoginService
{
    private class IdentityProvider : IWinFormsIdentityProviderInternal
    {
        private readonly ICluuAuthenticationProvider cluuAuthenticationProvider;
        private readonly CluuAsyncLazyCacheValue<ICluuIdentity> identityLoader;
        private readonly string password;
        private readonly string username;

        public IdentityProvider(ICluuAuthenticationProvider cluuAuthenticationProvider, string username, string password)
        {
            this.cluuAuthenticationProvider = cluuAuthenticationProvider;
            this.username = username;
            this.password = password;

            this.identityLoader = new CluuAsyncLazyCacheValue<ICluuIdentity>(TimeSpan.FromMinutes(30), this.CreateCluuIdentity);
        }

        async Task<ICluuIdentity> IWinFormsIdentityProviderInternal.GetIdentityAsync(CancellationToken cancellationToken)
        {
            return await this.identityLoader.GetValueAsync(cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<ICluuIdentity> CreateCluuIdentity(CancellationToken cancellationToken)
        {
            return await this.cluuAuthenticationProvider.AuthenticateViaCluuSecurityAsync(
                this.username,
                this.password,
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}
