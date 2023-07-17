using Cluu.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsCluuDemo.Hosting;
using WinFormsCluuDemo.Services.Identity;
using WinFormsCluuDemo.Services.Login;
using WinFormsCluuDemo.Services.Middleware;
using WinFormsCluuDemo.Services.Query;

namespace WinFormsCluuDemo;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static async Task Main()
    {
        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();

        await host.StartAsync().ConfigureAwait(false);

        try
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += HandleApplicationThreadException;

            var formFactory = host.Services.GetRequiredService<IFormFactory<MainForm>>();

            Application.Run(formFactory.Create());
        }
        finally
        {
            await host.StopAsync().ConfigureAwait(false);
        }
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Forms
        _ = services.AddAllAppForms();

        // Services
        _ = services.AddAllAppServices();

        // Cluu
        _ = services.AddCluuClient(cluu =>
        {
        });

        // Optionen
        _ = services.Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"));
    }

    private static void HandleApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
        _ = MessageBox.Show(e.Exception.Message);
    }
}
