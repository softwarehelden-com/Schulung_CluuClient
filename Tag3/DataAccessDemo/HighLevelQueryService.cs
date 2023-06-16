using Cluu.CQL;
using Cluu.DataAccess;
using Cluu.DataAccess.Extensions;
using Cluu.DataAccess.Linq;
using DataAccessDemo.EntityModel;
using DataAccessDemo.EntityModel.SwhOrgManagement;
using DataAccessDemo.Middleware;
using Microsoft.Extensions.Hosting;

namespace DataAccessDemo;

internal class HighLevelQueryService : BackgroundService
{
    private readonly ICluuMiddleware cluuMiddleware;
    private readonly IObjectContextFactory objectContextFactory;

    public HighLevelQueryService(
        IDemoObjectContextFactory objectContextFactory,
        ICluuMiddleware cluuMiddleware
    )
    {
        this.objectContextFactory = objectContextFactory;
        this.cluuMiddleware = cluuMiddleware;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this.cluuMiddleware.InvokeAsync(this.ExecuteInternalAsync, stoppingToken).ConfigureAwait(false);
    }

    private async Task ExecuteBatchedQueryAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteBatchedQueryAsync");

        var s = Person.CreateFieldSelector();

        var dataPager = new CluuRawDataPager(
            objectContextFactory: this.objectContextFactory,
            cluuClassName: s.GetCluuClassName(),
            cluuConstraint: null,
            selectFields: new EntitySelectFields(s.Caption),
            pageSize: 5
        );

        await dataPager.ProcessDataAsync(
            (batch, ct) =>
            {
                _ = ct;

                Console.WriteLine("- Batch " + batch.StartIndex + "-" + (batch.StartIndex + batch.Entities.Count));

                foreach (Person person in batch.Entities)
                {
                    Console.WriteLine("-- " + person.Caption);
                }

                return Task.CompletedTask;
            },
            cancellationToken
        ).ConfigureAwait(false);
    }

    private async Task ExecuteInternalAsync(CancellationToken cancellationToken)
    {
        await this.ExecuteSimpleQueryAsync(cancellationToken).ConfigureAwait(false);
        await this.ExecuteSimpleQuery2Async(cancellationToken).ConfigureAwait(false);
        await this.ExecuteLinqQueryAsync(cancellationToken).ConfigureAwait(false);
        await this.ExecuteLinqQuery2Async(cancellationToken).ConfigureAwait(false);
        await this.ExecuteBatchedQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteLinqQuery2Async(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteLinqQuery2Async");

        using var ctx = this.objectContextFactory.Create();

        var s = Person.CreateFieldSelector();

        string[] selectFields = new[] {
            s.Caption,
            s.Company.Caption
        };

        var persons = await (from x in ctx.ToQueryable<Person>(selectFields)
                             where x.Id < 10
                             orderby x.Caption
                             select x).ExecuteAsync(cancellationToken).ConfigureAwait(false);

        foreach (var person in persons)
        {
            Console.WriteLine("- " + person.Caption + ": " + person.Company?.Caption);
        }
    }

    private async Task ExecuteLinqQueryAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteLinqQueryAsync");

        using var ctx = this.objectContextFactory.Create();

        var s = Person.CreateFieldSelector();

        string[] selectFields = new[] { s.Caption };

        var persons = await (from x in ctx.ToQueryable<Person>(selectFields)
                             where x.Id < 10
                             orderby x.Caption
                             select x).ExecuteAsync(cancellationToken).ConfigureAwait(false);

        foreach (var person in persons)
        {
            Console.WriteLine("- " + person.Caption);
        }
    }

    private async Task ExecuteSimpleQuery2Async(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleQuery2Async");

        using var ctx = this.objectContextFactory.Create();

        var s = Person.CreateFieldSelector();

        string[] selectFields = new[] { s.Caption };

        var persons = await ctx.GetByConstraintAsync<Person>(
            constraint: CluuConstraint.Equal(s.Id, 1),
            selectFields: selectFields,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);

        foreach (var person in persons)
        {
            Console.WriteLine("- " + person.Caption);
        }
    }

    // Achtung, keine SelectFields, kein Constraint!!!
    private async Task ExecuteSimpleQueryAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleQueryAsync");

        using var ctx = this.objectContextFactory.Create();

        var persons = await ctx.GetByConstraintAsync<Person>(null, cancellationToken).ConfigureAwait(false);

        foreach (var person in persons)
        {
            Console.WriteLine("- " + person.Caption);
        }
    }
}
