using Cluu.Security.Authentication;
using SampleSolution1.Identity;

namespace SampleSolution1.Services.Login;

internal class CluuSecurityLoginService : ICluuSecurityLoginService
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
            var cluuIdentity = await this.cluuAuthenticationProvider.AuthenticateViaCluuSecurityAsync(
                username,
                password,
                cancellationToken
            ).ConfigureAwait(false);

            if (cluuIdentity == null)
            {
                return false;
            }

            this.winFormsIdentityProvider.SetCluuIdentity(cluuIdentity);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
