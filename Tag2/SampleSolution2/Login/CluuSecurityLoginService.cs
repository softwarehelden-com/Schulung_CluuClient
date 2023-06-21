using System.Threading;
using System.Threading.Tasks;
using Cluu.Security.Authentication;
using SampleSolutionWpf.Identity;

namespace SampleSolutionWpf.Login;

internal partial class CluuSecurityLoginService : ICluuSecurityLoginService
{
    private readonly ICluuAuthenticationProvider cluuAuthenticationProvider;
    private readonly IWpfCluuIdentityProvider wpfCluuIdentityProvider;

    public CluuSecurityLoginService(ICluuAuthenticationProvider cluuAuthenticationProvider,
        IWpfCluuIdentityProvider wpfCluuIdentityProvider)
    {
        this.cluuAuthenticationProvider = cluuAuthenticationProvider;
        this.wpfCluuIdentityProvider = wpfCluuIdentityProvider;
    }

    async Task<bool> ICluuSecurityLoginService.LoginAsync(string username, string password, CancellationToken cancellationToken)
    {
        bool result;

        try
        {
            var identityProvider = new IdentityProvider(this.cluuAuthenticationProvider, username, password);

            var identity = await ((IWpfCluuIdentityProviderInternal)identityProvider).GetIdentityAsync(cancellationToken).ConfigureAwait(false);

            result = identity != null;

            if (result)
            {
                this.wpfCluuIdentityProvider.SetCurrent(identityProvider);
            }
        }
        catch
        {
            result = false;
        }

        return result;
    }
}
