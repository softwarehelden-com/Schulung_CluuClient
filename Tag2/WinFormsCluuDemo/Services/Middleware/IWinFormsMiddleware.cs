namespace WinFormsCluuDemo.Services.Middleware;

public interface IWinFormsMiddleware
{
    Task InvokeAsync(Func<CancellationToken, Task> requestDelegate, CancellationToken cancellationToken = default);

    Task<T> InvokeAsync<T>(Func<CancellationToken, Task<T>> requestDelegate, CancellationToken cancellationToken = default);
}
