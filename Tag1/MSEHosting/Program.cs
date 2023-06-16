using Microsoft.Extensions.Hosting;

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
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();
