using Microsoft.Extensions.Logging;

public class MessageWriter : IMessageWriter
{
    private readonly ILogger<MessageWriter> logger;

    public MessageWriter(ILogger<MessageWriter> logger)
    {
        this.logger = logger;
    }

    public void Write(string message)
    {
        //this.logger.LogInformation($"Kein Strukturiertes Logging (message: \"{message}\")");

        this.logger.LogInformation("MessageWriter.Write(message: \"{message}\")", message);
    }
}
