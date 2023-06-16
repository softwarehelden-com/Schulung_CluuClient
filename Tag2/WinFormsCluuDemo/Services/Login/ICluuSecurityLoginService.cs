namespace WinFormsCluuDemo.Services.Login;

public interface ICluuSecurityLoginService
{
    Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken);
}
