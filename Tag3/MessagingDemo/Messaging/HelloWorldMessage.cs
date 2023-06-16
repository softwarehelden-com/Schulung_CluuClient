namespace MessagingDemo.Messaging;

internal class HelloWorldMessage
{
    public const string Topic = "cluu/client/messaging-demo/hello-world";

    public HelloWorldMessage(string text)
    {
        this.Text = text;
    }

    public string Text { get; }
}
