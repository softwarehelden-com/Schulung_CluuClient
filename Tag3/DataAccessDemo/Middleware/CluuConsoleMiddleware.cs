using Cluu.Client;
using Cluu.Hosting;

namespace DataAccessDemo.Middleware;

internal class CluuConsoleMiddleware : ICluuMiddleware
{
    private readonly IPreparedCluuWorkerIdentityScopeProvider preparedCluuWorkerIdentityScopeProvider;
    private readonly IServiceProvider serviceProvider;

    public CluuConsoleMiddleware(
        IServiceProvider serviceProvider,
        IPreparedCluuWorkerIdentityScopeProvider preparedCluuWorkerIdentityScopeProvider
    )
    {
        this.serviceProvider = serviceProvider;
        this.preparedCluuWorkerIdentityScopeProvider = preparedCluuWorkerIdentityScopeProvider;
    }

    async Task ICluuMiddleware.InvokeAsync(
        Func<CancellationToken, Task> requestDelegate,
        CancellationToken cancellationToken = default
    )
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var preparedIdentityScope = await this.preparedCluuWorkerIdentityScopeProvider.CreateAsync(cancellationToken).ConfigureAwait(false);

            using (preparedIdentityScope.Impersonate())
            {
                await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }

    async Task<T> ICluuMiddleware.InvokeAsync<T>(
        Func<CancellationToken, Task<T>> requestDelegate,
        CancellationToken cancellationToken = default
    )
    {
        using (this.serviceProvider.EnterAllCluuScopes())
        {
            var preparedIdentityScope = await this.preparedCluuWorkerIdentityScopeProvider.CreateAsync(cancellationToken).ConfigureAwait(false);

            using (preparedIdentityScope.Impersonate())
            {
                return await requestDelegate(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
