using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class MultipleUsersFoundException : Http409ConflictException
{
    private const string HttpExceptionMessage = "Multiple users found.";

    public MultipleUsersFoundException() : base(HttpExceptionMessage) { }
    
    public MultipleUsersFoundException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
