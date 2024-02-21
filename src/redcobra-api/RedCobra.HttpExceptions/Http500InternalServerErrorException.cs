namespace RedCobra.HttpExceptions;

public class Http500InternalServerErrorException : Http5xxServerException
{
    private const string HttpExceptionMessage = "HTTP 500 - Internal server error.";
    private const int HttpExceptionStatusCode = 500;

    public Http500InternalServerErrorException() : this(HttpExceptionMessage) { }

    public Http500InternalServerErrorException(string message) : base(message)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http500InternalServerErrorException(Exception innerException) : base(HttpExceptionMessage, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
    
    public Http500InternalServerErrorException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = HttpExceptionStatusCode;
    }
}
