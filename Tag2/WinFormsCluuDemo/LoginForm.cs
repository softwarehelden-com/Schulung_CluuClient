using Cluu.Backbone;
using WinFormsCluuDemo.Services.Login;

namespace WinFormsCluuDemo;

public partial class LoginForm : Form
{
    private readonly ICluuSecurityLoginService cluuSecurityLoginService;
    private readonly ISingleSignOnLoginService singleSignOnLoginService;

    public LoginForm(
        ISingleSignOnLoginService singleSignOnLoginService,
        ICluuSecurityLoginService cluuSecurityLoginService
    )
    {
        this.singleSignOnLoginService = singleSignOnLoginService;
        this.cluuSecurityLoginService = cluuSecurityLoginService;
        this.InitializeComponent();

        this.InitializeAuthMethods();
    }

    private async void HandleLoginButtonClick(object sender, EventArgs e)
    {
        var authMethod = (CluuDefaultAuthenticationMethod)this.loginTypeComboBox.SelectedValue;

        bool? result = null;

        if (authMethod == CluuDefaultAuthenticationMethod.IssuedToken)
        {
            result = await this.singleSignOnLoginService.LoginAsync(CancellationToken.None);
        }
        else if (authMethod == CluuDefaultAuthenticationMethod.CluuSecurity)
        {
            result = await this.cluuSecurityLoginService.LoginAsync(
                this.usernameTextBox.Text,
                this.passwordTextBox.Text,
                CancellationToken.None
            );
        }

        if (result == null)
        {
            _ = MessageBox.Show(this, "Das Loginverfahren wird noch nicht unterstützt.");
        }
        else if (result == true)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.None;
            _ = MessageBox.Show(this, "Das Login ist fehlgeschlagen.");
        }
    }

    private void HandleLoginTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        var authMethod = (CluuDefaultAuthenticationMethod?)this.loginTypeComboBox.SelectedValue;

        bool showUsernamePassword = authMethod == CluuDefaultAuthenticationMethod.CluuSecurity;

        this.usernameLabel.Visible = showUsernamePassword;
        this.usernameTextBox.Visible = showUsernamePassword;

        this.passwordLabel.Visible = showUsernamePassword;
        this.passwordTextBox.Visible = showUsernamePassword;
    }

    private void InitializeAuthMethods()
    {
        this.loginTypeComboBox.DisplayMember = nameof(LoginViewModel.Caption);
        this.loginTypeComboBox.ValueMember = nameof(LoginViewModel.AuthMethod);

        this.loginTypeComboBox.DataSource = new LoginViewModel[]{
            new LoginViewModel
            {
                Caption = "Benutzername / Passwort",
                AuthMethod = CluuDefaultAuthenticationMethod.CluuSecurity
            },
            new LoginViewModel
            {
                Caption = "Single-Sign-On",
                AuthMethod = CluuDefaultAuthenticationMethod.IssuedToken
            }
        };

        this.loginTypeComboBox.SelectedValue = CluuDefaultAuthenticationMethod.IssuedToken;
    }
}
