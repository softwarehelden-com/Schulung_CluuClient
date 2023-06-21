using SampleSolution1.Hosting;
using SampleSolution1.Middleware;
using SampleSolution1.Services.Query;

namespace SampleSolution1;

public partial class MainForm : Form
{
    private readonly FormFactory<LoginForm> loginFormFactory;
    private readonly IQueryService queryService;
    private readonly IWinFormsMiddleware winFormsMiddleware;

    public MainForm(
        FormFactory<LoginForm> loginFormFactory,
        IQueryService queryService,
        IWinFormsMiddleware winFormsMiddleware
    )
    {
        this.InitializeComponent();

        this.loginFormFactory = loginFormFactory;
        this.queryService = queryService;
        this.winFormsMiddleware = winFormsMiddleware;
    }

    private void HandleLoginButtonClicked(object sender, EventArgs e)
    {
        var loginForm = this.loginFormFactory();
        _ = loginForm.ShowDialog();
    }

    private async void HandleQueryButtonClickedAsync(object sender, EventArgs e)
    {
        using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
        {
            var usernames = await this.winFormsMiddleware.InvokeAsync(
                this.queryService.GetAllUsernamesAsync,
                //async cancellationToken => await queryService.GetAllUsernamesAsync(cancellationToken).ConfigureAwait(false)
                cts.Token
            );

            this.resultTextBox.Text = string.Join(", ", usernames);
        }
    }
}
