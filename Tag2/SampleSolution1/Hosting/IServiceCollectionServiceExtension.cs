using Microsoft.Extensions.DependencyInjection;
using SampleSolution1.Identity;
using SampleSolution1.Middleware;
using SampleSolution1.Services.Login;
using SampleSolution1.Services.Query;

namespace SampleSolution1.Hosting;

internal static class IServiceCollectionServiceExtension
{
    public static IServiceCollection AddAllAppServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICluuSecurityLoginService, CluuSecurityLoginService>()
            .AddSingleton<IQueryService, QueryService>()
            .AddSingleton<IWinFormsMiddleware, WinFormsMiddleware>()
            .AddSingleton<IWinFormsIdentityProvider, WinFormsIdentityProvider>();
    }
}
