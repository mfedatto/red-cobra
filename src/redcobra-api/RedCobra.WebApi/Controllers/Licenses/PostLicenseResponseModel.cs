namespace RedCobra.WebApi.Controllers.Licenses;

public record PostLicenseResponseModel
{
    public Guid LicenseId { get; init; }
    public string LicenseNumber { get; init; }
    public Guid UserId { get; init; }
    public string ExpirationDate { get; init; }
    public bool ACategory { get; init; }
    public bool BCategory { get; init; }
    public string DateOfBirth { get; init; }
    public Guid? LicenseFileId { get; init; }
    public string? Issuer { get; init; }
    public string? IssueDate { get; init; }
}
