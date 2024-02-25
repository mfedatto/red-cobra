using RedCobra.HttpExceptions;

namespace RedCobra.Domain.Exceptions;

public class UserAlreadyHasThisLicenseException : Http400BadRequestException
{
    private const string HttpExceptionMessage = "Lincese expired.";

    public UserAlreadyHasThisLicenseException() : base(HttpExceptionMessage) { }
    
    public UserAlreadyHasThisLicenseException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
