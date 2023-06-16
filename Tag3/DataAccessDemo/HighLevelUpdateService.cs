using Cluu.CQL;
using Cluu.DataAccess;
using DataAccessDemo.EntityModel;
using DataAccessDemo.EntityModel.SwhOrgManagement;
using DataAccessDemo.Middleware;
using Microsoft.Extensions.Hosting;

namespace DataAccessDemo;

internal class HighLevelUpdateService : BackgroundService
{
    private readonly ICluuMiddleware cluuMiddleware;
    private readonly IObjectContextFactory objectContextFactory;

    public HighLevelUpdateService(
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

    private async Task ExecuteInternalAsync(CancellationToken cancellationToken)
    {
        await this.ExecuteSimpleInsertAsync(cancellationToken).ConfigureAwait(false);
        await this.ExecuteSimpleUpdateAsync(cancellationToken).ConfigureAwait(false);
        await this.ExecuteSimpleDeleteAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteSimpleDeleteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleDeleteAsync");

        var s = Person.CreateFieldSelector();

        using var ctx = this.objectContextFactory.Create();

        var persons = await ctx.GetByConstraintAsync<Person>(
            CluuConstraint.And(
                CluuConstraint.Equal(s.FirstName, "Bart"),
                CluuConstraint.Equal(s.FirstName, "Simpson")
            ),
            cancellationToken,
            s.Id
        ).ConfigureAwait(false);

        if (persons.Count > 0)
        {
            var person = persons[0];

            ctx.Delete(person.Company);
            ctx.Delete(person);

            await ctx.SaveChangesAsync(MergeOption.NoTracking, cancellationToken).ConfigureAwait(false);
        }
    }

    private async Task ExecuteSimpleInsertAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleInsertAsync");

        using var ctx = this.objectContextFactory.Create();

        var person = ctx.New<Person>();

        person.FirstName = "Bart";
        person.LastName = "Simpson";

        person.Company = ctx.New<OrganizationUnit>(x =>
        {
            x.Caption = "Microsoft";
            x.Description = "Demo";
        });

        ctx.Attach(person);

        await ctx.SaveChangesAsync(MergeOption.NoTracking, cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteSimpleUpdateAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("ExecuteSimpleUpdateAsync");

        var s = Person.CreateFieldSelector();

        using var ctx = this.objectContextFactory.Create();

        var persons = await ctx.GetByConstraintAsync<Person>(
            CluuConstraint.And(
                CluuConstraint.Equal(s.FirstName, "Bart"),
                CluuConstraint.Equal(s.FirstName, "Simpson")
            ),
            cancellationToken,
            s.Id,
            s.CostCenter
        ).ConfigureAwait(false);

        foreach (var person in persons)
        {
            person.CostCenter = "123";
        }

        await ctx.SaveChangesAsync(MergeOption.NoTracking, cancellationToken).ConfigureAwait(false);
    }
}
