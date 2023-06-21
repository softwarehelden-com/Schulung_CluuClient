using Cluu.Backbone;
using Cluu.CQL;

namespace SampleSolution1.Services.Query;

internal class QueryService : IQueryService
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;

    public QueryService(ICluuBackboneProvider cluuBackboneProvider)
    {
        this.cluuBackboneProvider = cluuBackboneProvider;
    }

    async Task<IReadOnlyList<string>> IQueryService.GetAllUsernamesAsync(CancellationToken cancellationToken)
    {
        var result = await this.cluuBackboneProvider.QueryAsync(
            new CluuQuery("CluuSecurity.Login"),
            cancellationToken
        ).ConfigureAwait(false);

        return result.Entities.Values.Select(x => (string)x.PropertyValues["Username"]).ToArray();
    }
}
