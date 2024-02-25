using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class LicenseExpiredException : Http400BadRequestException
{
    private const string HttpExceptionMessage = "Lincese expired.";

    public LicenseExpiredException() : base(HttpExceptionMessage) { }
    
    public LicenseExpiredException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
