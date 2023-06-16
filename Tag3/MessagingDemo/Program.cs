using Cluu.Client;
using Cluu.Hosting;
using Cluu.Security.Authentication;
using MessagingDemo;
using MessagingDemo.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Info: In diesem Beispiel authentifizieren wir uns mit einem Client-Zeritifikat

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .UseConsoleLifetime()
    .Build();

await host.RunAsync(CancellationToken.None).ConfigureAwait(false);

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    _ = services
        .AddHostedService<App>();

    // Cluu
    _ = services.AddCluuClient(cluu =>
    {
        _ = cluu.TryAddWorkerIdentityProvider();
        _ = cluu.TryAddMqttMessageBus();
        _ = cluu.TryAddCluuLeaseClient();

        _ = cluu.TryAddCluuHostedServiceMessageSubscriber<HelloWorldMessageSubscriber, HelloWorldMessage>();
    });

    // Optionen
    _ = services
        .Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"))
        .Configure<CluuWorkerIdentityProviderOptions>(context.Configuration.GetSection("cluu:worker"));
}
