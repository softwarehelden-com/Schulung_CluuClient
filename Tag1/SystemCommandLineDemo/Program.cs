using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

var rootCommand = CreateRootCommand();
rootCommand.AddCommand(CreatePlusCommand());
rootCommand.AddCommand(CreateMinusCommand());

//return await rootCommand.InvokeAsync(new string[] { "-t" });
//return await rootCommand.InvokeAsync(new string[] { "--text", "Hello World" });
return await rootCommand.InvokeAsync(args);

static RootCommand CreateRootCommand()
{
    var textOption = new Option<string>("--text", "The text to print on the command line.")
    {
        IsRequired = true
    };
    textOption.AddAlias("-t");

    var rootCommand = new RootCommand("Sample app for System.CommandLine");
    rootCommand.AddOption(textOption);

    rootCommand.SetHandler(text => Console.WriteLine(text), textOption);

    return rootCommand;
}

static Command CreatePlusCommand()
{
    var numbersOption = new Option<int[]>("--numbers", "The numbers.")
    {
        IsRequired = true,
        AllowMultipleArgumentsPerToken = true
    };
    numbersOption.AddAlias("-n");

    var plusCommand = new Command("plus", "adds numbers");
    plusCommand.AddOption(numbersOption);

    plusCommand.SetHandler(numbers => Console.WriteLine(numbers.Sum()), numbersOption);

    return plusCommand;
}

static Command CreateMinusCommand()
{
    var numbersOption = new Option<int[]>("--numbers", "The numbers.")
    {
        IsRequired = true,
        AllowMultipleArgumentsPerToken = true
    };
    numbersOption.AddAlias("-n");

    var minusCommand = new Command("minus", "adds numbers");
    minusCommand.AddOption(numbersOption);

    minusCommand.Handler = CommandHandler.Create<MinusOptions>(options =>
        Console.WriteLine(options.Numbers[0] - options.Numbers.Skip(1).Sum())
    );

    return minusCommand;
}
