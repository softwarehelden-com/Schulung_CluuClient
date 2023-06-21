using System.Threading;
using System.Threading.Tasks;
using Cluu;

namespace SampleSolutionWpf.Identity;

public interface IWpfCluuIdentityProviderInternal
{
    Task<ICluuIdentity> GetIdentityAsync(CancellationToken cancellationToken);

    void InvalidateIdentity();
}
