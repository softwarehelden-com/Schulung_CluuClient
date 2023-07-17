using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

// Powershell als Admin: [System.Diagnostics.EventLog]::CreateEventSource("MyApp",'Application')
using var bootstrapLogger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.EventLog("MyApp", logName: "Application")
    .CreateLogger();

try
{
    using var host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
        {
            // Standardlogging entfernen. Nur Serilog verwenden.
            _ = builder.ClearProviders();
        })
        .UseSerilog((context, configuration) =>
        {
            // Konfiguration aus dem Abschnitt "Serilog" lesen
            _ = configuration.ReadFrom.Configuration(context.Configuration);
        })
        .UseConsoleLifetime()
        .Build();

    host.Services
        .GetRequiredService<ILogger<Program>>()
        .LogInformation("Zeitstempel {timestamp}", DateTime.Now);

    await host.RunAsync();
}
catch (Exception exception)
{
    bootstrapLogger.Fatal(exception, "Es ist was echt Schlimmes mit der Anwendung passiert");
}
