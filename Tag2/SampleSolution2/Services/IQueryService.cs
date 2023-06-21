using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleSolutionWpf.Services;

public interface IQueryService
{
    Task<IReadOnlyList<string>> GetAllUserNamesAsync(CancellationToken cancellationToken);
}
