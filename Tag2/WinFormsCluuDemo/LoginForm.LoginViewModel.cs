using Cluu.Backbone;

namespace WinFormsCluuDemo;

public partial class LoginForm
{
    private class LoginViewModel
    {
        public CluuDefaultAuthenticationMethod AuthMethod { get; set; }

        public string? Caption { get; set; }
    }
}
