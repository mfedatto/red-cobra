using RedCobra.Domain.Exceptions;

namespace RedCobra.Domain.BasicAuthentication;

public class BasicAuthenticationFactory
{
    public IBasicAuthenticationCredentials Create(string basicAuthenticationHeader)
    {
        if (basicAuthenticationHeader == null
            || !basicAuthenticationHeader.StartsWith("Basic "))
            throw new BadCredentialsHeaderException();
        
        string encodedCredentials = basicAuthenticationHeader.Split(' ')[1];
        string decodedCredentials = encodedCredentials.DecodeBase64();
        
        if (!decodedCredentials.Contains(':'))
            throw new BadCredentialsHeaderException();
        
        string[] decodedCredentialsParts = decodedCredentials.Split(':');
        
        return new BasicAuthenticationCredentials
            {
                Username = decodedCredentialsParts[0],
                Password = decodedCredentialsParts[1]
            };
    }
}

file static class StringExtensions
{
    public static string DecodeBase64(this string base64EncodedData)
    {
        return System.Text.Encoding
            .UTF8
            .GetString(
                Convert.FromBase64String(base64EncodedData));
    }
}

file record BasicAuthenticationCredentials : IBasicAuthenticationCredentials
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
