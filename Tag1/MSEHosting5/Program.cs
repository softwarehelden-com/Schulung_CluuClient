using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        // Konfiguration anpassen. Datei, CommandLine und Umgebungsvariablen sind schon vorkonfiguriert.
    })
    .ConfigureLogging(builder =>
    {
        // Logging anpassen. Konsole ist schon vorkonfiguriert.

        // Standard löschen und nur Logging auf der Konsole
        _ = builder.ClearProviders();
        //_ = builder.AddConsole();
        _ = builder.AddJsonConsole();
    })
    .ConfigureServices(services =>
    {
        // DependencyInjection-Container konfigurieren
        services.TryAddSingleton<IMessageWriter, MessageWriter>();
    })
    .UseConsoleLifetime()
    .Build();

var writer = host.Services.GetRequiredService<IMessageWriter>();

writer.Write("Hello World");

await host.RunAsync();
