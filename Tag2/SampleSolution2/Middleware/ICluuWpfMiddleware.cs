using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleSolutionWpf.Middleware
{
    public interface ICluuWpfMiddleware
    {
        Task InvokeAsync(Func<CancellationToken, Task> requestDelegate, CancellationToken cancellationToken = default);

        Task<TResult> InvokeAsync<TResult>(Func<CancellationToken, Task<TResult>> requestDelegate, CancellationToken cancellationToken = default);
    }
}
