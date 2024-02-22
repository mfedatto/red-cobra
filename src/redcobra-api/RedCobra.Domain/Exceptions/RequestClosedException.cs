using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class RequestClosedException : Http499ClientClosedRequestException
{
    private const string HttpExceptionMessage = "Request closed.";

    public RequestClosedException() : base(HttpExceptionMessage) { }
    
    public RequestClosedException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}