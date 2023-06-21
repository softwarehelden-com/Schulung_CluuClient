using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrosoftHost = Microsoft.Extensions.Hosting.Host;

namespace SampleSolutionWpf.Hosting;

internal static class HostProvider
{
    private static bool isInitialized = false;

    public static IHost Host { get; private set; }

    public static T GetRequiredService<T>()
    {
        return Host.Services.GetRequiredService<T>();
    }

    public static void Initialize(Action<HostBuilderContext, IServiceCollection> configureServices)
    {
        if (HostProvider.isInitialized)
        {
            throw new Exception("Host provider is already initialized.");
        }

        var builder = MicrosoftHost.CreateDefaultBuilder()
            .ConfigureServices(configureServices);

        HostProvider.Host = builder.Build();

        HostProvider.isInitialized = true;
    }
}
