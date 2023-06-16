using Cluu.Security.Authentication;
using WinFormsCluuDemo.Services.Identity;

namespace WinFormsCluuDemo.Services.Login;

internal partial class SingleSignOnLoginService : ISingleSignOnLoginService
{
    private readonly ICluuAuthenticationProvider cluuAuthenticationProvider;
    private readonly IWinFormsIdentityProvider winFormsIdentityProvider;

    public SingleSignOnLoginService(
        ICluuAuthenticationProvider cluuAuthenticationProvider,
        IWinFormsIdentityProvider winFormsIdentityProvider
    )
    {
        this.cluuAuthenticationProvider = cluuAuthenticationProvider;
        this.winFormsIdentityProvider = winFormsIdentityProvider;
    }

    async Task<bool> ISingleSignOnLoginService.LoginAsync(CancellationToken cancellationToken)
    {
        try
        {
            var identityProvider = new IdentityProvider(this.cluuAuthenticationProvider);

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
