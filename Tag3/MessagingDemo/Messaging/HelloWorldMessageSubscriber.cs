using Cluu.Messaging;

namespace MessagingDemo.Messaging;

internal class HelloWorldMessageSubscriber : CluuHostedServiceMessageSubscriber<HelloWorldMessage>
{
    public HelloWorldMessageSubscriber(IMessageBus messageBus)
        : base(messageBus)
    {
    }

    public override string Topic => HelloWorldMessage.Topic;

    protected override Task HandleMessageInternalAsync(HelloWorldMessage message, CancellationToken cancellationToken)
    {
        Console.WriteLine($"received {this.Topic}: {message.Text}");

        return Task.CompletedTask;
    }
}
