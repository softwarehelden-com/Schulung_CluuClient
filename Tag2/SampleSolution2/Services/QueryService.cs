using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cluu.Backbone;
using Cluu.CQL;

namespace SampleSolutionWpf.Services;

internal class QueryService : IQueryService
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;

    public QueryService(ICluuBackboneProvider cluuBackboneProvider)
    {
        this.cluuBackboneProvider = cluuBackboneProvider;
    }

    async Task<IReadOnlyList<string>> IQueryService.GetAllUserNamesAsync(CancellationToken cancellationToken)
    {
        var result = await this.cluuBackboneProvider.QueryAsync(
            new CluuQuery("CluuSecurity.Login"),
            cancellationToken
        ).ConfigureAwait(false);

        return result.Entities.Values.Select(x => (string)x.PropertyValues["Username"]).ToArray();
    }
}
