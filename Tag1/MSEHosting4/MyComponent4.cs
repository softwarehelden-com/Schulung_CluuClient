internal delegate IMessageWriter MessageWriterResolver();

internal class MyComponent4
{
    private readonly MessageWriterResolver messageWriterResolver;

    public MyComponent4(MessageWriterResolver messageWriterResolver)
    {
        this.messageWriterResolver = messageWriterResolver;
    }

    public void Execute()
    {
        var writer = this.messageWriterResolver();

        writer.Write("my message");
    }
}
