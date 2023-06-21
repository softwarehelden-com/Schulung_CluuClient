using System.Threading;
using System.Threading.Tasks;

namespace SampleSolutionWpf.Login;

public interface ICluuSecurityLoginService
{
    Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken);
}
