namespace RedCobra.HttpExceptions;

public class Http428PreconditionRequiredException : Http4xxClientException
{
    private const string HttpExceptionMessage = "HTTP 428 - Precondition required.";
    private const int HttpExceptionStatusCode = 428;

    public Http428PreconditionRequiredException() : this(HttpExceptionMessage) { }
    
    public Http428PreconditionRequiredException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http428PreconditionRequiredException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http428PreconditionRequiredException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }

}
