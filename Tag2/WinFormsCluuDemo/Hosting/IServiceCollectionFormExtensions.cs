using Microsoft.Extensions.DependencyInjection;

namespace WinFormsCluuDemo.Hosting;

internal static class IServiceCollectionFormExtensions
{
    public static IServiceCollection AddAllAppForms(this IServiceCollection services)
    {
        services.AddSingleton(
            typeof(IFormFactory<>), typeof(FormFactory<>)
        );

        return services;
    }

    private class FormFactory<T> : IFormFactory<T> where T : Form
    {
        private readonly IServiceProvider serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Create()
        {
            return ActivatorUtilities.CreateInstance<T>(this.serviceProvider);
        }
    }
}
