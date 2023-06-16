using Microsoft.Extensions.Hosting;

internal class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            Console.WriteLine(DateTime.Now);

            await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
        }
    }
}
