using Cluu.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleSolution1.Hosting;

namespace SampleSolution1;

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
            Application.ThreadException += HandleUnhandledException;

            var form = host.Services.GetRequiredService<MainForm>();

            Application.Run(form);
        }
        finally
        {
            await host.StopAsync().ConfigureAwait(false);
        }
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        _ = services.AddAllAppForms();

        _ = services.AddAllAppServices();

        _ = services.AddCluuClient(cluu =>
        {
        });

        _ = services.Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"));
    }

    private static void HandleUnhandledException(object sender, ThreadExceptionEventArgs e)
    {
        _ = MessageBox.Show(e.Exception.Message);
    }
}
