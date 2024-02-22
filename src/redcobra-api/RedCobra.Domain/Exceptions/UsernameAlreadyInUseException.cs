using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class UsernameAlreadyInUseException : Http409ConflictException
{
    private const string HttpExceptionMessage = "Username already in use.";

    public UsernameAlreadyInUseException() : base(HttpExceptionMessage) { }
    
    public UsernameAlreadyInUseException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
