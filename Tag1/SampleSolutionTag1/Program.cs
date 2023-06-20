using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using SampleSolutionTag1.Commands;
using Serilog;
using Serilog.Core;

namespace SampleSolutionTag1;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        using var bootstrapLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.EventLog("MyApp", logName: "Application")
            .CreateLogger();

        try
        {
            var rootCommand = new CommandLineBuilder(new PlusCommand())
                .AddMiddleware((context, next) => ErrorHandlingMiddleware(context, next, bootstrapLogger))
                .UseDefaults()
                .Build();

            int exitCode = await rootCommand.InvokeAsync(args);

            return exitCode;
        }
        catch (Exception exception)
        {
            bootstrapLogger.Fatal(exception, "Failed to initialize the command pipeline");

            return 1;
        }
    }

    private static async Task ErrorHandlingMiddleware(
        InvocationContext context,
        Func<InvocationContext, Task> next,
        Logger logger)
    {
        try
        {
            await next(context).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            logger.Fatal(exception, "Failed to execute the command");
        }
    }
}