namespace DataAccessDemo.Middleware;

public interface ICluuMiddleware
{
    Task InvokeAsync(Func<CancellationToken, Task> requestDelegate, CancellationToken cancellationToken = default);

    Task<T> InvokeAsync<T>(Func<CancellationToken, Task<T>> requestDelegate, CancellationToken cancellationToken = default);
}
