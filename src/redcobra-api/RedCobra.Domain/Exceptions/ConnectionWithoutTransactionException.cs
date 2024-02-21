using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class ConnectionWithoutTransactionException : Http500InternalServerErrorException
{
    private const string HttpExceptionMessage = "Connection without transaction.";

    public ConnectionWithoutTransactionException() : base(HttpExceptionMessage) { }
    
    public ConnectionWithoutTransactionException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
