using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

// $env:cluu__client__backendUrl="envvalue"
args = new string[] { "--cluu:client:backendUrl", "myValue" };

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        // Konfiguration anpassen. Datei, CommandLine und Umgebungsvariablen sind schon vorkonfiguriert.
    })
    .ConfigureServices((ctx, services) =>
    {
        _ = services.Configure<MyOptions>(ctx.Configuration.GetSection("cluu:client"));
    })
    .UseConsoleLifetime()
    .Build();

// Achtung: Der Host wurde noch nicht gestartet. Nicht notwendig, wenn es keine Hintergrunddienste
// gibt. ...Und man das wirklich weiß.

// Nach dem Erstellen des Hosts steht die Konfiguration zur Verfügung
var config = host.Services.GetRequiredService<IConfiguration>();

Console.WriteLine("hello: " + config["hello"]);

Console.WriteLine("mycount: " + config.GetValue<int>("mycount"));

Console.WriteLine("backendUrl: " + config["cluu:client:backendUrl"]);

Console.WriteLine("myOptions.backendUrl: " + config.GetSection("cluu:client").Get<MyOptions>().BackendUrl);

var options = host.Services.GetRequiredService<IOptions<MyOptions>>();
var optionsMonitor = host.Services.GetRequiredService<IOptionsMonitor<MyOptions>>();
var optionsSnapshot = host.Services.GetRequiredService<IOptionsSnapshot<MyOptions>>();
