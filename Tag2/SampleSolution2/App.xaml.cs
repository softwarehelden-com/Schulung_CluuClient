using System.Windows;
using Cluu.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleSolutionWpf.Hosting;

namespace SampleSolutionWpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        HostProvider.Initialize(this.ConfigureServices);

        HostProvider.GetRequiredService<MainWindow>().Show();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        _ = services.AddAllServices()
            .Configure<CluuClientOptions>(context.Configuration.GetSection("cluu:client"))
            .AddCluuClient(builder =>
            {
            }
        );
    }
}
