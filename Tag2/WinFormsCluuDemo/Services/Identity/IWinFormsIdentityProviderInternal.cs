using Cluu;

namespace WinFormsCluuDemo.Services.Identity;

internal interface IWinFormsIdentityProviderInternal
{
    Task<ICluuIdentity> GetIdentityAsync(CancellationToken cancellationToken);
}
