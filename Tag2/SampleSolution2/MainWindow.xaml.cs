using System.Windows;
using SampleSolutionWpf.Login;
using SampleSolutionWpf.Middleware;
using SampleSolutionWpf.Services;

namespace SampleSolutionWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ICluuWpfMiddleware cluuWpfMiddleware;
    private readonly WindowFactory<CluuLoginWindow> loginWindowFactory;
    private readonly IQueryService queryService;

    public MainWindow(
        WindowFactory<CluuLoginWindow> loginWindowFactory,
        IQueryService queryService,
        ICluuWpfMiddleware cluuWpfMiddleware
    )
    {
        this.loginWindowFactory = loginWindowFactory;
        this.queryService = queryService;
        this.cluuWpfMiddleware = cluuWpfMiddleware;

        this.InitializeComponent();
        this.InitializeControls();
    }

    private void HandleLoginClicked(object sender, RoutedEventArgs e)
    {
        _ = this.loginWindowFactory().ShowDialog();
    }

    private async void HandleQueryClickedAsync(object sender, RoutedEventArgs e)
    {
        var result = await this.cluuWpfMiddleware.InvokeAsync(
            this.queryService.GetAllUserNamesAsync
        );

        this.resultBox.Text = string.Join(", ", result);
    }

    private void InitializeControls()
    {
        this.loginButton.Click += this.HandleLoginClicked;
        this.queryButton.Click += this.HandleQueryClickedAsync;
    }
}
