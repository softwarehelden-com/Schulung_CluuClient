using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SampleSolutionWpf.Identity;
using SampleSolutionWpf.Login;
using SampleSolutionWpf.Middleware;
using SampleSolutionWpf.Services;

namespace SampleSolutionWpf.Hosting;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        return services.AddCluuWpfMiddleware()
            .AddQueryService()
            .AddCluuLogin()
            .AddAllWindows();
    }

    public static IServiceCollection AddAllWindows(this IServiceCollection services)
    {
        return services.AddWindow<MainWindow>();
    }

    public static IServiceCollection AddCluuLogin(this IServiceCollection services)
    {
        services.TryAddSingleton<ICluuSecurityLoginService, CluuSecurityLoginService>();
        services.TryAddSingleton<IWindowsDomainLoginService, WindowsDomainLoginService>();
        _ = services.AddWindow<CluuLoginWindow>();
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

    public static IServiceCollection AddWindow<T>(this IServiceCollection services) where T : Window
    {
        _ = services.AddTransient<T>()
            .AddSingleton<WindowFactory<T>>(x => () => x.GetRequiredService<T>());

        return services;
    }
}
