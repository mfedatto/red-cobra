namespace RedCobra.HttpExceptions;

public class Http499ClientClosedRequestException : Http4xxClientException
{
    private const string HttpExceptionMessage = "HTTP 499 - Client closed request.";
    private const int HttpExceptionStatusCode = 499;

    public Http499ClientClosedRequestException() : this(HttpExceptionMessage) { }
    
    public Http499ClientClosedRequestException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http499ClientClosedRequestException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http499ClientClosedRequestException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }

}
