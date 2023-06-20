using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SampleSolutionTag1.Options;

namespace SampleSolutionTag1.Services;

internal class MyAppServices
{
    private readonly MyAppOptions myAppOptions;
    private readonly ICalculator calculator;
    private readonly IIntInputReader intInputReader;
    private readonly IHostApplicationLifetime lifetime;

    public MyAppServices(
        IOptions<MyAppOptions> myAppOptions,
        ICalculator calculator,
        IIntInputReader intInputReader,
        IHostApplicationLifetime lifetime
    )
    {
        this.myAppOptions = myAppOptions.Value;
        this.calculator = calculator;
        this.intInputReader = intInputReader;
        this.lifetime = lifetime;
    }

    public async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int value = 0;

        while (value < this.myAppOptions.MaxValue)
        {
            int input = await this.intInputReader.ReadAsync(stoppingToken).ConfigureAwait(false);

            value = this.calculator.Add(value, input);
        }

        this.lifetime.StopApplication();
    }
}