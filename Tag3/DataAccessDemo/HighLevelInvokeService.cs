using Cluu.Serialization.Json;
using DataAccessDemo.EntityModel.DemoClientDevelopment.Actions;
using DataAccessDemo.EntityModel.SwhOrgManagement.Actions;
using DataAccessDemo.Middleware;
using Microsoft.Extensions.Hosting;

namespace DataAccessDemo;

internal class HighLevelInvokeService : BackgroundService
{
    private readonly ICluuMiddleware cluuMiddleware;
    private readonly IExportPersonsInvokeAction exportPersonsInvokeAction;
    private readonly IGetStreamInvokeAction getStreamInvokeAction;

    public HighLevelInvokeService(
        ICluuMiddleware cluuMiddleware,
        IGetStreamInvokeAction getStreamInvokeAction,
        IExportPersonsInvokeAction exportPersonsInvokeAction
    )
    {
        this.cluuMiddleware = cluuMiddleware;
        this.getStreamInvokeAction = getStreamInvokeAction;
        this.exportPersonsInvokeAction = exportPersonsInvokeAction;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this.cluuMiddleware.InvokeAsync(this.ExecuteInternalAsync, stoppingToken).ConfigureAwait(false);
    }

    private async Task ExecuteInternalAsync(CancellationToken cancellationToken)
    {
        await this.ExecuteSimpleInvokeAsync(cancellationToken).ConfigureAwait(false);
        await this.ExecuteSimpleInvoke2Async(cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteSimpleInvoke2Async(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleInvoke2Async");

        var response = await this.exportPersonsInvokeAction.InvokeAsync(
            new ExportPersonsInvokeRequest
            {
                PersonConstraint = "Id == 1",
                ExportedFileType = 0
            },
            cancellationToken
        ).ConfigureAwait(false);

        Console.WriteLine("Response: " + CluuJsonSerializer.Serialize(response));
    }

    private async Task ExecuteSimpleInvokeAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleInvokeAsync");

        using var stream = await this.getStreamInvokeAction.InvokeAsync(cancellationToken).ConfigureAwait(false);

        Console.WriteLine("Response: <binary>");
    }
}
