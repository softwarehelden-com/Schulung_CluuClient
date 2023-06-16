using System.CommandLine;
using ConsoleAndServiceDemo.Commands;

var rootCommand = new RunApplicationCommand();
rootCommand.AddCommand(new SetCredentialsCommand());

await rootCommand.InvokeAsync(args).ConfigureAwait(false);
