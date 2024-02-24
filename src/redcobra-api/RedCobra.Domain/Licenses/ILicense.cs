namespace RedCobra.Domain.Licenses;

public interface ILicense
{
    Guid LicenseId { get; }
    string LicenseNumber { get; }
    Guid UserId { get; }
    DateTime ExpirationDate { get; }
    bool ACategory { get; }
    bool BCategory { get; }
    DateTime DateOfBirth { get; }
    Guid? LicenseFileId { get; }
    string? Issuer { get; }
    DateTime? IssueDate { get; }
}
