namespace RedCobra.HttpExceptions;

public class Http400BadRequestException : Http4xxClientException
{
    private const string HttpExceptionMessage = "HTTP 400 - Bad request.";
    private const int HttpExceptionStatusCode = 400;

    public Http400BadRequestException() : this(HttpExceptionMessage) { }

    public Http400BadRequestException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http400BadRequestException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http400BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
}
