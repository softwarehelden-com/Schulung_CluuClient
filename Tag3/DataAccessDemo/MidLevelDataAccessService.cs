using Cluu;
using Cluu.Backbone;
using Cluu.CQL;
using Cluu.Serialization.Json;
using DataAccessDemo.Middleware;
using Microsoft.Extensions.Hosting;

namespace DataAccessDemo;

internal class MidLevelDataAccessService : BackgroundService
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;
    private readonly ICluuMiddleware cluuMiddleware;

    public MidLevelDataAccessService(
        ICluuBackboneProvider cluuBackboneProvider,
        ICluuMiddleware cluuMiddleware
    )
    {
        this.cluuBackboneProvider = cluuBackboneProvider;
        this.cluuMiddleware = cluuMiddleware;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this.cluuMiddleware.InvokeAsync(this.ExecuteQueryAsync, stoppingToken).ConfigureAwait(false);
        await this.cluuMiddleware.InvokeAsync(this.ExecuteUpdateAsync, stoppingToken).ConfigureAwait(false);
        await this.cluuMiddleware.InvokeAsync(this.ExecuteInvokeStreamedAsync, stoppingToken).ConfigureAwait(false);
        //await this.cluuMiddleware.InvokeAsync(this.ExecuteInvoke2Async, stoppingToken).ConfigureAwait(false);
        await this.cluuMiddleware.InvokeAsync(this.ExecuteReadBinaryAsync, stoppingToken).ConfigureAwait(false);
    }

    private async Task ExecuteInvoke2Async(CancellationToken cancellationToken)
    {
        Console.WriteLine("Executing Invoke...");

        var request = new { personConstraint = (string)null, exportedFileType = 0 };

        Console.WriteLine("Request: " + CluuJsonSerializer.Serialize(request));

        object response = await this.cluuBackboneProvider.InvokeAsync<object, object>(
            actionName: "SwhOrgManagement.AddIns.DefaultAddIn.ExportPersons",
            message: request,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);

        Console.WriteLine("Response: " + CluuJsonSerializer.Serialize(response));
    }

    private async Task ExecuteInvokeStreamedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Executing Invoke...");

        using var stream = await this.cluuBackboneProvider.InvokeWithResponseStreamAsync(
            actionName: "DemoClientDevelopment.AddIns.Demo.GetStream",
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);

        Console.WriteLine("Response: <binary>");
    }

    private async Task ExecuteQueryAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Executing Query...");

        var result = await this.cluuBackboneProvider.QueryAsync(
            new CluuQuery(
                cluuClassName: "SwhOrgManagement.Person",
                constraint: CluuConstraint.Equal("FirstName", "Jörg"),
                selectFields: new string[] { "Caption", "Company.Caption" }
            ),
            cancellationToken
        ).ConfigureAwait(false);

        var entities = result.Entities.Values
            .Select(x => CluuJsonSerializer.Serialize(x));

        Console.WriteLine(string.Join(Environment.NewLine, entities));
    }

    private async Task ExecuteReadBinaryAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Executing ReadBinary...");

        var response = await this.cluuBackboneProvider.ReadBinaryPropertyAsync(
            cluuClassName: "SwhOrgManagement.Person",
            keyValue: 1,
            binaryPropertyName: "PhotoFileContent",
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);

        using var stream = response.Stream;

        Console.WriteLine("Response: " + response.FileName);
    }

    private async Task ExecuteUpdateAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Executing Update...");

        var change = CluuEntityChange.Update(
            cluuClassName: "SwhOrgManagement.Person",
            keyValue: 1,
            propertyValues: new Dictionary<string, object> { { "LastName", "Metzler99" } }
        );

        Console.WriteLine(CluuJsonSerializer.Serialize(change));

        _ = await this.cluuBackboneProvider.UpdateAsync(
            new[] { change },
            CluuUpdateReturnType.None,
            cancellationToken
        ).ConfigureAwait(false);
    }
}
