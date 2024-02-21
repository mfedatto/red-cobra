using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class ConnectionInUseByOtherTransactionException : Http500InternalServerErrorException
{
    private const string HttpExceptionMessage = "Connection in use by other transaction.";

    public ConnectionInUseByOtherTransactionException() : base(HttpExceptionMessage) { }
    
    public ConnectionInUseByOtherTransactionException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
