namespace RedCobra.WebApi.Controllers.Licenses;

public record PostLicenseResponseModel
{
    public Guid LicenseId { get; init; }
    public string LicenseNumber { get; init; }
    public Guid UserId { get; init; }
    public DateTime ExpirationDate { get; init; }
    public bool ACategory { get; init; }
    public bool BCategory { get; init; }
    public DateTime BirthDate { get; init; }
    public Guid? LicenseFileId { get; init; }
    public string? Issuer { get; init; }
    public DateTime? IssueDate { get; init; }
}
