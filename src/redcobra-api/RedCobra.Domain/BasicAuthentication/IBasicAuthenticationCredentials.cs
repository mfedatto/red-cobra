namespace RedCobra.Domain.BasicAuthentication;

public interface IBasicAuthenticationCredentials
{
    string Username { get; }
    string Password { get; }
}
