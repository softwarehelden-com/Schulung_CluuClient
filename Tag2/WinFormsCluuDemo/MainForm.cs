using Cluu.Backbone;
using WinFormsCluuDemo.Services.Middleware;
using WinFormsCluuDemo.Services.Query;

namespace WinFormsCluuDemo;

public partial class MainForm : Form
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;
    private readonly FormFactory<LoginForm> loginFormFactory;
    private readonly IQueryPersonService queryPersonService;
    private readonly IWinFormsMiddleware winFormsMiddleware;

    public MainForm(
        ICluuBackboneProvider cluuBackboneProvider,
        FormFactory<LoginForm> loginFormFactory,
        IWinFormsMiddleware winFormsMiddleware,
        IQueryPersonService queryPersonService
    )
    {
        this.InitializeComponent();

        this.cluuBackboneProvider = cluuBackboneProvider;
        this.loginFormFactory = loginFormFactory;
        this.winFormsMiddleware = winFormsMiddleware;
        this.queryPersonService = queryPersonService;
    }

    private void HandleLoginButtonClick(object sender, EventArgs e)
    {
        var loginForm = this.loginFormFactory();

        var result = loginForm.ShowDialog(this);

        if (result == DialogResult.OK)
        {
            // TODO
        }
    }

    private async void HandleQueryButtonClick(object sender, EventArgs e)
    {
        var result = await this.winFormsMiddleware.InvokeAsync(
            cancellationToken => this.queryPersonService.GetAllPersonNamesAsync(cancellationToken)
        );

        this.resultTextBox.Text = string.Join(", ", result);
    }

    private async void HandleTestCluuConnectionButtonClick(object sender, EventArgs e)
    {
        bool result = await this.cluuBackboneProvider.IsAvailableAsync(CancellationToken.None);

        this.resultTextBox.Text = "Cluu verfügbar: " + result;
    }
}
