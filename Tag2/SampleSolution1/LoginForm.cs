using SampleSolutionWinForms.Services.Login;

namespace SampleSolutionWinForms;

public partial class LoginForm : Form
{
    private readonly ICluuSecurityLoginService loginService;

    public LoginForm(ICluuSecurityLoginService loginService)
    {
        this.InitializeComponent();

        this.loginService = loginService;
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void HandleLoginButtonClickedAsync(object sender, EventArgs e)
    {
        string? username = this.usernameInput.Text;
        string? password = this.passwordInput.Text;

        if (await this.loginService.LoginAsync(username, password, CancellationToken.None))
        {
            // login erfolgreich -> Dialog schließen und anderes tun
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
        else
        {
            _ = MessageBox.Show(this, "Die Anmeldung ist fehlgeschlagen.");
        }
    }
}
