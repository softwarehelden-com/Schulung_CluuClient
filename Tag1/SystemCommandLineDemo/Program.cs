using System.CommandLine;
using SystemCommandLineDemo;

var rootCommand = new AppRootCommand();
rootCommand.AddCommand(new PlusCommand());
rootCommand.AddCommand(new MinusCommand());

//return await rootCommand.InvokeAsync(new string[] { "-t" });
//return await rootCommand.InvokeAsync(new string[] { "--text", "Hello World" });
return await rootCommand.InvokeAsync(args);
