using Cluu;

namespace WinFormsCluuDemo.Services.Identity;

internal class WinFormsIdentityProvider : IWinFormsIdentityProvider
{
    private readonly object mutex = new();
    private IWinFormsIdentityProviderInternal? current;

    void IDisposable.Dispose()
    {
    }

    async Task<ICluuIdentity?> ICluuIdentityProvider.GetIdentityAsync(CancellationToken cancellationToken)
    {
        IWinFormsIdentityProviderInternal current;

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

    void IWinFormsIdentityProvider.SetCurrent(IWinFormsIdentityProviderInternal identityProvider)
    {
        lock (this.mutex)
        {
            this.current = identityProvider;
        }
    }
}
