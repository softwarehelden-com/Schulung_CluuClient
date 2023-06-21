using System.Threading;
using System.Threading.Tasks;
using Cluu;

namespace SampleSolutionWpf.Identity;

internal class WpfCluuIdentityProvider : IWpfCluuIdentityProvider
{
    private readonly object mutex = new();
    private IWpfCluuIdentityProviderInternal current;

    async Task<ICluuIdentity> IWpfCluuIdentityProvider.GetIdentityAsync(CancellationToken cancellationToken)
    {
        IWpfCluuIdentityProviderInternal current;

        lock (this.mutex)
        {
            current = this.current;

            if (current == null)
            {
                return null;
            }
        }

        return await current.GetIdentityAsync(cancellationToken).ConfigureAwait(false);
    }

    void IWpfCluuIdentityProvider.InvalidateIdentity()
    {
        lock (this.mutex)
        {
            this.current?.InvalidateIdentity();
        }
    }

    void IWpfCluuIdentityProvider.SetCurrent(IWpfCluuIdentityProviderInternal identityProvider)
    {
        lock (this.mutex)
        {
            this.current = identityProvider;
        }
    }
}
