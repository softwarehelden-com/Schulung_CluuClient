using Cluu;
using Cluu.Threading;
using SampleSolutionWinForms.Hosting;

namespace SampleSolutionWinForms.Identity;

internal class WinFormsIdentityProvider : IWinFormsIdentityProvider
{
    private readonly FormFactory<LoginForm> loginFormFactory;
    private CluuLazyCacheValue<ICluuIdentity>? cluuIdentityLoader;

    public WinFormsIdentityProvider(FormFactory<LoginForm> loginFormFactory)
    {
        this.loginFormFactory = loginFormFactory;
    }

    Task<ICluuIdentity> IWinFormsIdentityProvider.GetCluuIdentityAsync(CancellationToken cancellationToken)
    {
        if (this.cluuIdentityLoader?.Value == null)
        {
            var loginForm = this.loginFormFactory();

            _ = loginForm.ShowDialog();
        }

        return Task.FromResult(this.cluuIdentityLoader?.Value);
    }

    void IWinFormsIdentityProvider.SetCluuIdentity(ICluuIdentity cluuIdentity)
    {
        this.cluuIdentityLoader = new CluuLazyCacheValue<ICluuIdentity>(
            TimeSpan.FromHours(12),
            () => cluuIdentity
        );
    }
}
