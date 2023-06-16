using System.Security.Cryptography;
using System.Text;

namespace ConsoleAndServiceDemo.Credentitals;

internal class CredentialsStore
{
    private const string entropy = "L#Ua(hECFg~H&j'7'FGx";

    private const string fileName = "pass";

    private CredentialsStore()
    {
    }

    public static CredentialsStore Instance { get; } = new CredentialsStore();

    public string? Load()
    {
        if (!File.Exists(fileName))
        {
            return null;
        }

        byte[] secret = ProtectedData.Unprotect(
            File.ReadAllBytes(fileName),
            Encoding.UTF8.GetBytes(entropy),
            DataProtectionScope.CurrentUser
        );

        return Encoding.UTF8.GetString(secret);
    }

    public void Save(string password)
    {
        // https://learn.microsoft.com/de-de/dotnet/api/system.security.cryptography.protecteddata?view=windowsdesktop-7.0
        byte[] secret = ProtectedData.Protect(
            Encoding.UTF8.GetBytes(password),
            Encoding.UTF8.GetBytes(entropy),
            DataProtectionScope.CurrentUser
        );

        File.WriteAllBytes(fileName, secret);
    }
}
