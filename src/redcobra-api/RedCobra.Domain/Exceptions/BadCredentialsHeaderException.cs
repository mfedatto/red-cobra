using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class BadCredentialsHeaderException : Http400BadRequestException
{
    private const string HttpExceptionMessage = "Bad credentials header.";

    public BadCredentialsHeaderException() : base(HttpExceptionMessage) { }
    
    public BadCredentialsHeaderException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}