using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace SystemCommandLineDemo;

internal class MinusCommand : Command
{
    public MinusCommand()
        : base("minus", "subtracts numbers")
    {
        var numbersOption = new Option<int[]>("--numbers", "The numbers.")
        {
            IsRequired = true,
            AllowMultipleArgumentsPerToken = true
        };
        numbersOption.AddAlias("-n");

        this.AddOption(numbersOption);

        this.Handler = CommandHandler.Create<MinusOptions>(options =>
            this.Execute(options)
        );
    }

    private void Execute(MinusOptions options)
    {
        Console.WriteLine(options.Numbers[0] - options.Numbers.Skip(1).Sum());
    }
}
