using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinFormsThreadingDemo;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static async Task Main()
    {
        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                _ = services.AddSingleton<ICalcService, CalcService>();

                _ = services.AddTransient<MainForm>();
            })
            .UseConsoleLifetime()
            .Build();

        await host.StartAsync().ConfigureAwait(false);

        try
        {
            ApplicationConfiguration.Initialize();

            var form = host.Services.GetRequiredService<MainForm>();

            Application.Run(form);
        }
        finally
        {
            await host.StopAsync().ConfigureAwait(false);
        }
    }
}
