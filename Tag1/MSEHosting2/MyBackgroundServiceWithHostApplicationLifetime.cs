using Microsoft.Extensions.Hosting;

internal class MyBackgroundServiceWithHostApplicationLifetime : BackgroundService, IAsyncDisposable
{
    private readonly IHostApplicationLifetime hostApplicationLifetime;
    private readonly CancellationTokenTaskSource startedTaskSource;

    public MyBackgroundServiceWithHostApplicationLifetime(IHostApplicationLifetime hostApplicationLifetime)
    {
        this.hostApplicationLifetime = hostApplicationLifetime;

        // ApplicationStarted ist ein CancellationToken und wird als Task verpackt.
        this.startedTaskSource = new CancellationTokenTaskSource(hostApplicationLifetime.ApplicationStarted);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await this.startedTaskSource.DisposeAsync().ConfigureAwait(false);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Task ist beendet, sobald alle Hintergrunddienste hochgefahren wurden (ApplicationStarted
        // wurde ausgelöst)
        await this.startedTaskSource.Task.ConfigureAwait(false);

        Console.WriteLine("Do some async Work");

        // Stop der Anwendung erzwingen
        this.hostApplicationLifetime.StopApplication();
    }
}
