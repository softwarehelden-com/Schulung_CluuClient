using System.Threading;
using System.Threading.Tasks;

namespace SampleSolutionTag1.Services;

internal interface IIntInputReader
{
    Task<int> ReadAsync(CancellationToken cancellationToken);
}