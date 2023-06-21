using System;
using System.Threading;
using System.Threading.Tasks;
using Cluu;
using Cluu.Security.Authentication;
using Cluu.Threading;
using SampleSolutionWpf.Identity;

namespace SampleSolutionWpf.Login;

internal partial class CluuSecurityLoginService
{
    private class IdentityProvider : IWpfCluuIdentityProviderInternal
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

            this.identityLoader = new CluuAsyncLazyCacheValue<ICluuIdentity>(
                TimeSpan.FromMinutes(30),
                this.CreateCluuIdentity
            );
        }

        async Task<ICluuIdentity> IWpfCluuIdentityProviderInternal.GetIdentityAsync(CancellationToken cancellationToken)
        {
            return await this.identityLoader.GetValueAsync(cancellationToken).ConfigureAwait(false);
        }

        void IWpfCluuIdentityProviderInternal.InvalidateIdentity()
        {
            this.identityLoader.Clear();
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
