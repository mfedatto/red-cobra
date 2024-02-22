using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class UserNotFoundException : Http404NotFoundException
{
    private const string HttpExceptionMessage = "User not found.";

    public UserNotFoundException() : base(HttpExceptionMessage) { }
    
    public UserNotFoundException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
