using Cluu.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SampleSolutionWpf.Identity;
using SampleSolutionWpf.Login;
using SampleSolutionWpf.Middleware;
using SampleSolutionWpf.Services;

namespace SampleSolutionWpf.Hosting;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCluuServices(this IServiceCollection services, HostBuilderContext context)
    {
        return services
            .Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"))
            .AddCluuClient(builder =>
            {
            });
    }

    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        return services
            .AddCluuWpfMiddleware()
            .AddQueryService()
            .AddCluuLogin()
            .AddAllWindows();
    }

    public static IServiceCollection AddAllWindows(this IServiceCollection services)
    {
        return services.AddSingleton(typeof(IWindowFactory<>), typeof(WindowFactory<>));
    }

    public static IServiceCollection AddCluuLogin(this IServiceCollection services)
    {
        services.TryAddSingleton<ICluuSecurityLoginService, CluuSecurityLoginService>();
        services.TryAddSingleton<IWindowsDomainLoginService, WindowsDomainLoginService>();
        services.TryAddSingleton<IWpfCluuIdentityProvider, WpfCluuIdentityProvider>();

        return services;
    }

    public static IServiceCollection AddCluuWpfMiddleware(this IServiceCollection services)
    {
        services.TryAddSingleton<ICluuWpfMiddleware, CluuWpfMiddleware>();

        return services;
    }

    public static IServiceCollection AddQueryService(this IServiceCollection services)
    {
        services.TryAddSingleton<IQueryService, QueryService>();

        return services;
    }
}
