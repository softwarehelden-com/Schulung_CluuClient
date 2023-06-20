using Microsoft.Extensions.DependencyInjection;
using WinFormsCluuDemo.Services.Identity;
using WinFormsCluuDemo.Services.Login;
using WinFormsCluuDemo.Services.Middleware;
using WinFormsCluuDemo.Services.Query;

namespace WinFormsCluuDemo.Hosting;

internal static class IServiceCollectionServiceExtensions
{
    public static IServiceCollection AddAllAppServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IWinFormsMiddleware, WinFormsMiddleware>()

            .AddSingleton<IWinFormsIdentityProvider, WinFormsIdentityProvider>()

            .AddSingleton<ISingleSignOnLoginService, SingleSignOnLoginService>()
            .AddSingleton<ICluuSecurityLoginService, CluuSecurityLoginService>()
            .AddSingleton<IQueryPersonService, QueryPersonService>();
    }
}
