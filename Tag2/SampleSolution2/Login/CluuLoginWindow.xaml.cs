using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Cluu.Backbone;

namespace SampleSolutionWpf.Login;

/// <summary>
/// Interaction logic for CluuLoginWindow.xaml
/// </summary>
public partial class CluuLoginWindow : Window
{
    private static readonly DependencyProperty DescriptionTextProperty
        = DependencyProperty.Register(nameof(DescriptionText), typeof(string), typeof(CluuLoginWindow), new PropertyMetadata(string.Empty));

    private static readonly DependencyProperty PasswordBoxVisibilityProperty
        = DependencyProperty.Register(nameof(PasswordBoxVisibility), typeof(Visibility), typeof(CluuLoginWindow), new PropertyMetadata(Visibility.Visible));

    private static readonly DependencyProperty UserNameTextBoxVisibilityProperty
                = DependencyProperty.Register(nameof(UserNameTextBoxVisibility), typeof(Visibility), typeof(CluuLoginWindow), new PropertyMetadata(Visibility.Visible));

    private readonly ICluuSecurityLoginService cluuSecurityLoginProvider;
    private readonly IWindowsDomainLoginService windowsDomainLoginService;

    public CluuLoginWindow(
        ICluuSecurityLoginService cluuSecurityLoginProvider,
        IWindowsDomainLoginService windowsDomainLoginService
    )
    {
        this.cluuSecurityLoginProvider = cluuSecurityLoginProvider;
        this.windowsDomainLoginService = windowsDomainLoginService;

        this.InitializeComponent();
        this.InitializeControls();

        this.DataContext = this;
    }

    public string DescriptionText
    {
        get => (string)this.GetValue(DescriptionTextProperty);
        set => this.SetValue(DescriptionTextProperty, value);
    }

    public Visibility PasswordBoxVisibility
    {
        get => (Visibility)this.GetValue(PasswordBoxVisibilityProperty);
        set => this.SetValue(PasswordBoxVisibilityProperty, value);
    }

    public Visibility UserNameTextBoxVisibility
    {
        get => (Visibility)this.GetValue(UserNameTextBoxVisibilityProperty);
        set => this.SetValue(UserNameTextBoxVisibilityProperty, value);
    }

    private void HandleAuthSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedViewModel = (LoginViewModel)this.authMethodSelector.SelectedItem;

        var visibility = selectedViewModel.AuthMethod != CluuDefaultAuthenticationMethod.IssuedToken ? Visibility.Visible : Visibility.Collapsed;

        this.UserNameTextBoxVisibility = visibility;
        this.PasswordBoxVisibility = visibility;

        this.DescriptionText = selectedViewModel.Description;
    }

    private async void HandleLoginClicked(object sender, RoutedEventArgs e)
    {
        var selectedViewModel = (LoginViewModel)this.authMethodSelector.SelectedItem;

        bool loginSuccessful = false;

        if (selectedViewModel.AuthMethod is CluuDefaultAuthenticationMethod.CluuSecurity or CluuDefaultAuthenticationMethod.WindowsDomain)
        {
            string userName = this.userNameInput.Text;
            string password = this.credentialsInput.Password;

            if (selectedViewModel.AuthMethod == CluuDefaultAuthenticationMethod.CluuSecurity)
            {
                loginSuccessful = await this.cluuSecurityLoginProvider.LoginAsync(userName, password, CancellationToken.None);
            }
            else if (selectedViewModel.AuthMethod == CluuDefaultAuthenticationMethod.WindowsDomain)
            {
                loginSuccessful = await this.windowsDomainLoginService.LoginAsync(userName, password, CancellationToken.None);
            }
        }

        if (loginSuccessful)
        {
            this.DialogResult = true;
            this.Close();
        }
    }

    private void InitializeControls()
    {
        this.authMethodSelector.SelectionChanged += this.HandleAuthSelectionChanged;

        this.authMethodSelector.ItemsSource = new LoginViewModel[]{
        new LoginViewModel
        {
            Caption = "Cluu-Benutzer",
            AuthMethod = CluuDefaultAuthenticationMethod.CluuSecurity,
            Description = "Bitte melden Sie sich mit Ihren Cluu-Zugangsdaten an."
        },
        new LoginViewModel
        {
            Caption = "Windows-Domain",
            AuthMethod = CluuDefaultAuthenticationMethod.WindowsDomain,
            Description = "Bitte melden Sie sich mit Ihren Windows Zugangsdaten an."
        }
    };

        this.authMethodSelector.SelectedValue = CluuDefaultAuthenticationMethod.CluuSecurity;

        this.loginButton.Click += this.HandleLoginClicked;
    }
}
