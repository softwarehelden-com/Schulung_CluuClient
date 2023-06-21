using Cluu;

namespace SampleSolution1.Identity;

internal interface IWinFormsIdentityProvider
{
    Task<ICluuIdentity> GetCluuIdentityAsync(CancellationToken cancellationToken);

    void SetCluuIdentity(ICluuIdentity cluuIdentity);
}
