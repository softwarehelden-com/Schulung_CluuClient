namespace SampleSolutionWinForms.Services.Query;

public interface IQueryService
{
    Task<IReadOnlyList<string>> GetAllUsernamesAsync(CancellationToken cancellationToken);
}
