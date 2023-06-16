using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        // Konfiguration anpassen. Datei, CommandLine und Umgebungsvariablen sind schon vorkonfiguriert.
    })
    .ConfigureLogging(builder =>
    {
        // Logging anpassen. Konsole ist schon vorkonfiguriert.
    })
    .ConfigureServices(services =>
    {
        // DependencyInjection-Container konfigurieren
        _ = services.AddSingleton<IMessageWriter, MessageWriter>();
        //services.TryAddSingleton<IMessageWriter, MessageWriter>();

        //services.AddSingleton<MessageWriterResolver>(x => () => x.GetRequiredService<IMessageWriter>());

        //services.AddSingleton<IMessageWriter, MessageWriter>();

        // Bonusfrage: was passiert bei mehrfacher Registrierung?
        //services
        //    .AddScoped<IMessageWriter, FileMessageWriter>()
        //    .AddSingleton<IMessageWriter, HttpMessageWriter>()
        //    .AddTransient<IMessageWriter, ConsoleMessageWriter>();
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();
