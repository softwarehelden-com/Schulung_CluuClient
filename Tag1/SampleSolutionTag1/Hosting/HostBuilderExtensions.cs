using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SampleSolutionTag1.Hosting;

internal static class HostBuilderExtensions
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
    {
        _ = builder.ConfigureLogging(loggingBuilder =>
            {
                // Standardlogging entfernen. Nur Serilog verwenden.
                _ = loggingBuilder.ClearProviders();
            })
            .UseSerilog((context, configuration) =>
            {
                // Konfiguration aus dem Abschnitt "Serilog" lesen
                _ = configuration.ReadFrom.Configuration(context.Configuration);
            }
        );

        return builder;
    }
}