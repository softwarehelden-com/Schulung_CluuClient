internal class MyComponent : IDisposable
{
    private readonly IMessageWriter messageWriter;

    public MyComponent(IMessageWriter messageWriter)
    {
        this.messageWriter = messageWriter;
    }

    void IDisposable.Dispose()
    {
        // Dispose auf interne Komponenten ...

        // Achtung: Niemals Dispose auf Abhängigkeiten
    }
}
