using Cluu.Backbone;
using Cluu.CQL;
using ConsoleAndServiceDemo.Middleware;
using Microsoft.Extensions.Hosting;

namespace ConsoleAndServiceDemo;

internal class App : BackgroundService
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;
    private readonly ICluuMiddleware cluuMiddleware;

    public App(
        ICluuMiddleware cluuMiddleware,
        ICluuBackboneProvider cluuBackboneProvider
    )
    {
        this.cluuMiddleware = cluuMiddleware;
        this.cluuBackboneProvider = cluuBackboneProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            await this.cluuMiddleware.InvokeAsync(this.ExecuteAsyncInternalAsync, stoppingToken).ConfigureAwait(false);

            await Task.Delay(2000).ConfigureAwait(false);
        }
    }

    private async Task ExecuteAsyncInternalAsync(CancellationToken cancellationToken)
    {
        var result = await this.cluuBackboneProvider.QueryAsync(
            new CluuQuery("SwhOrgManagement.Person", null, "Caption"),
            cancellationToken
        ).ConfigureAwait(false);

        var personNames = result.Entities.Values
            .Select(x => (string)x.PropertyValues["Caption"]);

        Console.WriteLine(personNames.FirstOrDefault());
    }
}
