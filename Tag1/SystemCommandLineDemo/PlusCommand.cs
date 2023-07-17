using System.CommandLine;

namespace SystemCommandLineDemo;

internal class PlusCommand : Command
{
    public PlusCommand()
        : base("plus", "adds numbers")
    {
        var numbersOption = new Option<int[]>("--numbers", "The numbers.")
        {
            IsRequired = true,
            AllowMultipleArgumentsPerToken = true
        };
        numbersOption.AddAlias("-n");

        this.AddOption(numbersOption);

        this.SetHandler(numbers => Execute(numbers), numbersOption);
    }

    private static void Execute(int[] numbers)
    {
        Console.WriteLine(numbers.Sum());
    }
}
