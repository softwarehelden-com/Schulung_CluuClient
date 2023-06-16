using Microsoft.Extensions.DependencyInjection;

namespace WinFormsCluuDemo.Hosting;

internal static class IServiceCollectionExtensions
{
    public static IServiceCollection AddForm<T>(this IServiceCollection services) where T : Form
    {
        return services
            .AddTransient<T>()
            .AddSingleton<FormFactory<T>>(x => () => x.GetRequiredService<T>());
    }
}
