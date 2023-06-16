using Cluu;
using Cluu.Hosting;
using WinFormsCluuDemo.Services.Identity;

namespace WinFormsCluuDemo.Services.Middleware;

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

    async Task IWinFormsMiddleware.InvokeAsync(
        Func<CancellationToken, Task> requestDelegate,
        CancellationToken cancellationToken = default
    )
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var identity = await this.winFormsIdentityProvider.GetIdentityAsync(cancellationToken).ConfigureAwait(false);

            using (this.cluuIdentityAccessor.Impersonate(identity))
            {
                await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }

    async Task<T> IWinFormsMiddleware.InvokeAsync<T>(
        Func<CancellationToken, Task<T>> requestDelegate,
        CancellationToken cancellationToken = default
    )
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var identity = await this.winFormsIdentityProvider.GetIdentityAsync(cancellationToken).ConfigureAwait(false);

            using (this.cluuIdentityAccessor.Impersonate(identity))
            {
                return await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
