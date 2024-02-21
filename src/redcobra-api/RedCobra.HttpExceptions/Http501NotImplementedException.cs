namespace RedCobra.HttpExceptions;

public class Http501NotImplementedException : Http5xxServerException
{
    private const string HttpExceptionMessage = "HTTP 501 - Not implemented.";
    private const int HttpExceptionStatusCode = 501;

    public Http501NotImplementedException() : this(HttpExceptionMessage) { }

    public Http501NotImplementedException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http501NotImplementedException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http501NotImplementedException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
}
