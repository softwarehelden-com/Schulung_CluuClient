using Cluu.Backbone;

namespace SampleSolutionWpf.Login;

public partial class CluuLoginWindow
{
    private class LoginViewModel
    {
        public CluuDefaultAuthenticationMethod AuthMethod { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }
    }
}
