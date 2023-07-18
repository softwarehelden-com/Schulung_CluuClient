using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleSolutionWpf.Hosting;
using SampleSolutionWpf.Services;

namespace SampleSolutionWpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost host;

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        await this.host.StopAsync();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        this.DispatcherUnhandledException += this.HandleDispatcherUnhandledException;

        this.host = Host.CreateDefaultBuilder()
            .ConfigureServices(this.ConfigureServices)
            .Build();

        await this.host.StartAsync();

        var mainWindowFactory = this.host.Services.GetRequiredService<IWindowFactory<MainWindow>>();

        mainWindowFactory.Create().Show();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        _ = services
            .AddAllServices()
            .AddAllCluuServices(context);
    }

    private void HandleDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        _ = MessageBox.Show(e.Exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        e.Handled = true;
    }
}
