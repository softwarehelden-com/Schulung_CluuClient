using System.Collections.Generic;
using System.CommandLine;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SampleSolutionTag1.Hosting;
using SampleSolutionTag1.Options;
using SampleSolutionTag1.Services;

namespace SampleSolutionTag1.Commands;

public class PlusCommand : RootCommand
{
    public PlusCommand()
        : base("adds numbers")
    {
        Argument<int?> maxArg = new("max");

        this.AddArgument(maxArg);

        this.SetHandler(this.ExecuteAsync, maxArg);
    }

    private async Task ExecuteAsync(int? max)
    {
        using var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(configuation =>
            {
                if (max != null)
                {
                    _ = configuation.AddInMemoryCollection(
                        new Dictionary<string, string>
                        {
                            { "myApp:maxValue", max.ToString() }
                        }
                    );
                }
            })
            .ConfigureSerilog()
            .ConfigureServices((ctx, services) =>
            {
                services.TryAddSingleton<MyAppServices>();
                services.TryAddSingleton<ICalculator, Calculator>();
                services.TryAddSingleton<IIntInputReader, ConsoleIntInputReader>();

                _ = services.Configure<MyAppOptions>(ctx.Configuration.GetSection("myApp"));
            })
            .UseConsoleLifetime()
            .Build();

        await host.StartAsync().ConfigureAwait(false);

        _ = host.Services.
            GetRequiredService<MyAppServices>()
            .ExecuteAsync(
                host.Services.GetRequiredService<IHostApplicationLifetime>().ApplicationStopping
            )
            .ConfigureAwait(false);

        await host.StopAsync().ConfigureAwait(false);
    }
}