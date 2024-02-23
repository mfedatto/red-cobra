using RedCobra.Domain.Licenses;

namespace RedCobra.WebApi.Controllers.Licenses;

public static class ModelExtensions
{
    public static GetLicenseResponseModel ToGetLicenseResponseModel(
        this ILicense license)
    {
        return new GetLicenseResponseModel
        {
            LicenseId = license.LicenseId,
            LicenseNumber = license.LicenseNumber,
            UserId = license.UserId,
            ExpirationDate = license.ExpirationDate,
            ACategory = license.ACategory,
            BCategory = license.BCategory,
            BirthDate = license.BirthDate,
            Issuer = license.Issuer,
            IssueDate = license.IssueDate
        };
    }
    
    public static PostLicenseResponseModel ToPostLicenseResponseModel(
        this ILicense license)
    {
        return new PostLicenseResponseModel
        {
            LicenseId = license.LicenseId,
            LicenseNumber = license.LicenseNumber,
            UserId = license.UserId,
            ExpirationDate = license.ExpirationDate,
            ACategory = license.ACategory,
            BCategory = license.BCategory,
            BirthDate = license.BirthDate,
            Issuer = license.Issuer,
            IssueDate = license.IssueDate
        };
    }
}