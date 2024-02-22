using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class BadCredentialsException : Http400BadRequestException
{
    private const string HttpExceptionMessage = "Bad credentials header.";

    public BadCredentialsException() : base(HttpExceptionMessage) { }
    
    public BadCredentialsException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}