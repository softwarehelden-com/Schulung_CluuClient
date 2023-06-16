using Cluu.Backbone;
using Cluu.CQL;

namespace WinFormsCluuDemo.Services.Query;

internal class QueryPersonService : IQueryPersonService
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;

    public QueryPersonService(
        ICluuBackboneProvider cluuBackboneProvider
    )
    {
        this.cluuBackboneProvider = cluuBackboneProvider;
    }

    async Task<IReadOnlyList<string>> IQueryPersonService.GetAllPersonNamesAsync(CancellationToken cancellationToken)
    {
        var result = await this.cluuBackboneProvider.QueryAsync(
            new CluuQuery("SwhOrgManagement.Person", null, "Caption"),
            cancellationToken
        ).ConfigureAwait(false);

        return result.Entities.Values
            .Select(x => (string)x.PropertyValues["Caption"])
            .ToArray();
    }
}
