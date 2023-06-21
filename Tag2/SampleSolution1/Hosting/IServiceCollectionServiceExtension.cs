using Microsoft.Extensions.DependencyInjection;
using SampleSolutionWinForms.Identity;
using SampleSolutionWinForms.Middleware;
using SampleSolutionWinForms.Services.Login;
using SampleSolutionWinForms.Services.Query;

namespace SampleSolutionWinForms.Hosting;

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
