using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Environment.CurrentDirectory = Path.GetDirectoryName(
    new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath
);

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        // Konfiguration anpassen. Datei, CommandLine und Umgebungsvariablen sind schon vorkonfiguriert.
    })
    .ConfigureLogging(builder =>
    {
        // Logging anpassen. Konsole ist schon vorkonfiguriert.
    })
    .ConfigureServices(services =>
    {
        // DependencyInjection-Container konfigurieren
        _ = services.AddHostedService<MyBackgroundService>();
        _ = services.AddHostedService<MyBackgroundServiceWithHostApplicationLifetime>();
    })
    // Aus NuGet-Paket "Microsoft.Extensions.Hosting.WindowsServices"
    .UseWindowsService()
    .Build();

await host.RunAsync();
