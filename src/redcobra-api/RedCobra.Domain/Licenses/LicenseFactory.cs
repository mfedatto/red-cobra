namespace RedCobra.Domain.Licenses;

public class LicenseFactory
{
    public ILicense Create(
        Guid licenseId,
        string licenseNumber,
        Guid userId,
        DateTime expirationDate,
        bool aCategory,
        bool bCategory,
        DateTime birthDate,
        Guid? licenseFileId,
        string? issuer,
        DateTime? issueDate)
    {
        return new License
        {
            LicenseId = licenseId,
            LicenseNumber = licenseNumber,
            UserId = userId,
            ExpirationDate = expirationDate,
            ACategory = aCategory,
            BCategory = bCategory,
            BirthDate = birthDate,
            LicenseFileId = licenseFileId,
            Issuer = issuer,
            IssueDate = issueDate
        };
    }
}

file record License : ILicense
{
    public Guid LicenseId { get; init; }
    public required string LicenseNumber { get; init; }
    public Guid UserId { get; init; }
    public DateTime ExpirationDate { get; init; }
    public bool ACategory { get; init; }
    public bool BCategory { get; init; }
    public DateTime BirthDate { get; init; }
    public Guid? LicenseFileId { get; init; }
    public string? Issuer { get; init; }
    public DateTime? IssueDate { get; init; }
}
