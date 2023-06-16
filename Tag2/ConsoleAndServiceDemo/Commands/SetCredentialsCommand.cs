using System.CommandLine;
using ConsoleAndServiceDemo.Credentitals;

namespace ConsoleAndServiceDemo.Commands;

internal class SetCredentialsCommand : Command
{
    public SetCredentialsCommand()
        : base("pass", "Setzt das Passwort / die Credentials für den Worker")
    {
        var pass = new Argument<string>("password", "the password")
        {
            Name = "password"
        };

        this.AddArgument(pass);

        this.SetHandler(this.Execute, pass);
    }

    private void Execute(string password)
    {
        CredentialsStore.Instance.Save(password);
    }
}
