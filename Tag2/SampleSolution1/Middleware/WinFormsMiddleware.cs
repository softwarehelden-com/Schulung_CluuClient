using Cluu;
using Cluu.Hosting;
using SampleSolutionWinForms.Identity;

namespace SampleSolutionWinForms.Middleware;

internal class WinFormsMiddleware : IWinFormsMiddleware
{
    private readonly ICluuIdentityAccessor cluuIdentityAccessor;
    private readonly IServiceProvider serviceProvider;
    private readonly IWinFormsIdentityProvider winFormsIdentityProvider;

    public WinFormsMiddleware(
        IServiceProvider serviceProvider,
        ICluuIdentityAccessor cluuIdentityAccessor,
        IWinFormsIdentityProvider winFormsIdentityProvider
    )
    {
        this.serviceProvider = serviceProvider;
        this.cluuIdentityAccessor = cluuIdentityAccessor;
        this.winFormsIdentityProvider = winFormsIdentityProvider;
    }

    async Task<TResult> IWinFormsMiddleware.InvokeAsync<TResult>(Func<CancellationToken, Task<TResult>> requestDelegate, CancellationToken cancellationToken)
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var cluuIdentity = await this.winFormsIdentityProvider.GetCluuIdentityAsync(cancellationToken).ConfigureAwait(false);

            using (this.cluuIdentityAccessor.Impersonate(cluuIdentity))
            {
                return await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }

    async Task IWinFormsMiddleware.InvokeAsync(Func<CancellationToken, Task> requestDelegate, CancellationToken cancellationToken)
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var cluuIdentity = await this.winFormsIdentityProvider.GetCluuIdentityAsync(cancellationToken).ConfigureAwait(false);

            using (this.cluuIdentityAccessor.Impersonate(cluuIdentity))
            {
                await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
