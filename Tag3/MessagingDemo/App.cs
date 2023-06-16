using Cluu.Client.Runtime;
using Cluu.Messaging;
using MessagingDemo.Messaging;
using Microsoft.Extensions.Hosting;

namespace MessagingDemo;

internal class App : BackgroundService
{
    private readonly ICluuLeaseClient cluuLeaseClient;
    private readonly IMessageBus messageBus;

    public App(
        IMessageBus messageBus,
        ICluuLeaseClient cluuLeaseClient
    )
    {
        this.messageBus = messageBus;
        this.cluuLeaseClient = cluuLeaseClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            var lease = await this.cluuLeaseClient.AcquireLeaseAsync("MessagingDemo-publish", stoppingToken).ConfigureAwait(false);
            if (!lease.IsAcquired)
            {
                await Task.Delay(5000, stoppingToken).ConfigureAwait(false);

                continue;
            }

            try
            {
                await this.ExecuteAsyncInternalAsync(stoppingToken).ConfigureAwait(false);

                await Task.Delay(2000, stoppingToken).ConfigureAwait(false);
            }
            finally
            {
                _ = lease.ReleaseAsync(stoppingToken).ConfigureAwait(false);
            }
        }
    }

    private async Task ExecuteAsyncInternalAsync(CancellationToken cancellationToken)
    {
        var message = new HelloWorldMessage("Guten Tag Welt " + DateTime.Now);

        await this.messageBus.PublishAsync(
            HelloWorldMessage.Topic,
            message,
            cancellationToken
        ).ConfigureAwait(false);

        Console.WriteLine($"published to {HelloWorldMessage.Topic}: {message.Text}");
    }
}
