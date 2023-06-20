using Microsoft.Extensions.DependencyInjection;

namespace WinFormsCluuDemo.Hosting;

public delegate T FormFactory<T>() where T : Form;

internal static class IServiceCollectionFormExtensions
{
    public static IServiceCollection AddAllAppForms(this IServiceCollection services)
    {
        return services
            .AddForm<MainForm>()
            .AddForm<LoginForm>();
    }

    private static IServiceCollection AddForm<T>(this IServiceCollection services) where T : Form
    {
        return services
            .AddTransient<T>()
            .AddSingleton<FormFactory<T>>(x => () => x.GetRequiredService<T>());
    }
}
