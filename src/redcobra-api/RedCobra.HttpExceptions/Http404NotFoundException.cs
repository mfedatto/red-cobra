namespace RedCobra.HttpExceptions;

public class Http404NotFoundException : Http4xxClientException
{
    private const string HttpExceptionMessage = "HTTP 404 - Not found.";
    private const int HttpExceptionStatusCode = 404;

    public Http404NotFoundException() : this(HttpExceptionMessage) { }
    
    public Http404NotFoundException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http404NotFoundException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http404NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }

}
