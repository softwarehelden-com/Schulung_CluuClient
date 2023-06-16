internal class MyComponent2
{
    private readonly IEnumerable<IMessageWriter> messageWriters;

    public MyComponent2(IEnumerable<IMessageWriter> messageWriters)
    {
        this.messageWriters = messageWriters;
    }
}
