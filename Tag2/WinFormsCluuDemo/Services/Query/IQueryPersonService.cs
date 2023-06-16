namespace WinFormsCluuDemo.Services.Query;

public interface IQueryPersonService
{
    Task<IReadOnlyList<string>> GetAllPersonNamesAsync(CancellationToken cancellationToken);
}
