using System.CommandLine;

namespace SystemCommandLineDemo;

internal class AppRootCommand : RootCommand
{
    public AppRootCommand()
        : base("Sample app for System.CommandLine")
    {
        var textOption = new Option<string>("--text", "The text to print on the command line.")
        {
            IsRequired = true
        };
        textOption.AddAlias("-t");

        this.AddOption(textOption);

        this.SetHandler(text => this.Execute(text), textOption);
    }

    private void Execute(string text)
    {
        Console.WriteLine(text);
    }
}
