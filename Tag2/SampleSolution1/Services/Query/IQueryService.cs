namespace SampleSolution1.Services.Query;

public interface IQueryService
{
    Task<IReadOnlyList<string>> GetAllUsernamesAsync(CancellationToken cancellationToken);
}
