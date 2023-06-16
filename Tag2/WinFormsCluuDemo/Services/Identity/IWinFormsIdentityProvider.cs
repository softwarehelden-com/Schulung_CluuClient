using Cluu;

namespace WinFormsCluuDemo.Services.Identity;

internal interface IWinFormsIdentityProvider : ICluuIdentityProvider
{
    void SetCurrent(IWinFormsIdentityProviderInternal identityProvider);
}
