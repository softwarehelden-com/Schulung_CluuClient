public class MessageWriter : IMessageWriter, IAsyncMessageWriter
{
    void IMessageWriter.Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }

    async Task IAsyncMessageWriter.WriteAsync(string message)
    {
        await Console.Out.WriteLineAsync(
            $"MessageWriter.Write(message: \"{message}\")"
        ).ConfigureAwait(false);
    }
}
