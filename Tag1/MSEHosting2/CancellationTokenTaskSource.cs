internal class CancellationTokenTaskSource : IAsyncDisposable
{
    private readonly CancellationTokenRegistration registration;
    private readonly TaskCompletionSource tcs;

    public CancellationTokenTaskSource(CancellationToken cancellationToken)
    {
        // CancellationToken in eine async-Variante umbauen
        this.tcs = new TaskCompletionSource();

        // Warten, bis alle Hintergrunddienste hochgefahren sind.
        this.registration = cancellationToken.Register(
            () => this.tcs.SetResult()
        );
    }

    public Task Task => this.tcs.Task;

    public async ValueTask DisposeAsync()
    {
        await this.registration.DisposeAsync().ConfigureAwait(false);
    }
}
