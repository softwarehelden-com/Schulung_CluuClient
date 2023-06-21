using System.Threading;
using System.Threading.Tasks;
using Cluu;

namespace SampleSolutionWpf.Identity;

public interface IWpfCluuIdentityProvider
{
    Task<ICluuIdentity> GetIdentityAsync(CancellationToken cancellationToken);

    void InvalidateIdentity();

    void SetCurrent(IWpfCluuIdentityProviderInternal identityProvider);
}
