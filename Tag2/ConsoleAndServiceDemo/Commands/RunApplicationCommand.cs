using System.CommandLine;
using System.CommandLine.Invocation;
using Cluu.Client;
using Cluu.Hosting;
using Cluu.Security.Authentication;
using ConsoleAndServiceDemo.Credentitals;
using ConsoleAndServiceDemo.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAndServiceDemo.Commands;

internal class RunApplicationCommand : RootCommand
{
    public RunApplicationCommand() : base("Führt die Anwendung aus")
    {
        this.SetHandler(this.Execute);
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        _ = services
            .AddHostedService<App>()
            .AddSingleton<ICluuMiddleware, CluuConsoleMiddleware>();

        // Cluu
        _ = services.AddCluuClient(cluu =>
        {
            _ = cluu.TryAddWorkerIdentityProvider();
        });

        // Optionen
        _ = services
            .Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"))
            .Configure<CluuWorkerIdentityProviderOptions>(context.Configuration.GetSection("cluu:worker"))
            .PostConfigure<CluuWorkerIdentityProviderOptions>(x => x.Credential = CredentialsStore.Instance.Load());
    }

    private async Task Execute(InvocationContext invocationContext)
    {
        var cancellationToken = invocationContext.GetCancellationToken();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices(this.ConfigureServices)
            .UseConsoleLifetime()
            .Build();

        await host.RunAsync(cancellationToken).ConfigureAwait(false);
    }
}
