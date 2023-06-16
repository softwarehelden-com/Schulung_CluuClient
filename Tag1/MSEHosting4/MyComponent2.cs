using Microsoft.Extensions.DependencyInjection;

internal class MyComponent3
{
    private readonly IServiceProvider serviceProvider;

    public MyComponent3(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Execute()
    {
        var writer = this.serviceProvider.GetRequiredService<IMessageWriter>();

        writer.Write("my message");
    }
}
