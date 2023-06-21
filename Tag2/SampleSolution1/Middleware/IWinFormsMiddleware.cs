namespace SampleSolutionWinForms.Middleware;

public interface IWinFormsMiddleware
{
    Task<TResult> InvokeAsync<TResult>(Func<CancellationToken, Task<TResult>> requestDelegate, CancellationToken cancellationToken = default);

    Task InvokeAsync(Func<CancellationToken, Task> requestDelegate, CancellationToken cancellationToken = default);
}
