public interface IAsyncMessageWriter
{
    Task WriteAsync(string message);
}
