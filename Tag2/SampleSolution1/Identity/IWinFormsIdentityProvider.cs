using Cluu;

namespace SampleSolutionWinForms.Identity;

internal interface IWinFormsIdentityProvider
{
    Task<ICluuIdentity> GetCluuIdentityAsync(CancellationToken cancellationToken);

    void SetCluuIdentity(ICluuIdentity cluuIdentity);
}
