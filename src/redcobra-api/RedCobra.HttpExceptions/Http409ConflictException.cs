namespace RedCobra.HttpExceptions;

public class Http409ConflictException : Http4xxClientException
{
    private const string HttpExceptionMessage = "HTTP 409 - Conflict.";
    private const int HttpExceptionStatusCode = 409;

    public Http409ConflictException() : this(HttpExceptionMessage) { }
    
    public Http409ConflictException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http409ConflictException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http409ConflictException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }

}
