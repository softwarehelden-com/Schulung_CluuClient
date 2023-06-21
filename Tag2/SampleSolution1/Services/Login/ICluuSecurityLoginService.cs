namespace SampleSolution1.Services.Login;

public interface ICluuSecurityLoginService
{
    Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken);
}
