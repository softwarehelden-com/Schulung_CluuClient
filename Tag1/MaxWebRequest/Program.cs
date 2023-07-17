using System.Diagnostics;

var sw = Stopwatch.StartNew();

using var httpClient = new HttpClient();
using var sem = new SemaphoreSlim(10, 10);
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

var tasks = new List<Task<HttpResponseMessage>>();

for (int i = 0; i < 100; i++)
{
    tasks.Add(getAsync(httpClient, sem, cts.Token));
}

await Task.WhenAll(tasks);

sw.Stop();

Console.WriteLine(sw.ElapsedMilliseconds);

async Task<HttpResponseMessage> getAsync(HttpClient httpClient, SemaphoreSlim sem, CancellationToken cancellationToken)
{
    await sem.WaitAsync(cancellationToken);

    try
    {
        using var response = await httpClient.GetAsync("https://google.de", cancellationToken);

        response.EnsureSuccessStatusCode();

        return response;
    }
    finally
    {
        sem.Release();
    }
}