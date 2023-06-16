namespace WinFormsCluuDemo.Services.Login;

public interface ISingleSignOnLoginService
{
    Task<bool> LoginAsync(CancellationToken cancellationToken);
}
