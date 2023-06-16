using Cluu.Security.Authentication;
using WinFormsCluuDemo.Services.Identity;

namespace WinFormsCluuDemo.Services.Login;

internal partial class CluuSecurityLoginService : ICluuSecurityLoginService
{
    private readonly ICluuAuthenticationProvider cluuAuthenticationProvider;
    private readonly IWinFormsIdentityProvider winFormsIdentityProvider;

    public CluuSecurityLoginService(
        ICluuAuthenticationProvider cluuAuthenticationProvider,
        IWinFormsIdentityProvider winFormsIdentityProvider
    )
    {
        this.cluuAuthenticationProvider = cluuAuthenticationProvider;
        this.winFormsIdentityProvider = winFormsIdentityProvider;
    }

    async Task<bool> ICluuSecurityLoginService.LoginAsync(string username, string password, CancellationToken cancellationToken)
    {
        try
        {
            var identityProvider = new IdentityProvider(this.cluuAuthenticationProvider, username, password);

            var cluuIdentity = await ((IWinFormsIdentityProviderInternal)identityProvider).GetIdentityAsync(cancellationToken).ConfigureAwait(false);

            if (cluuIdentity == null)
            {
                return false;
            }

            this.winFormsIdentityProvider.SetCurrent(identityProvider);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
