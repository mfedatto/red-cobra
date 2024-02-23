namespace RedCobra.Domain.Licenses;

public interface ILicenseApplication
{
    Task<IEnumerable<ILicense>> GetUserLicensesList(
        Guid userId,
        bool? aCategory,
        bool? bCategory,
        bool includeExpired,
        CancellationToken cancellationToken);
    Task<ILicense> AddLicense(
        ILicense license,
        CancellationToken cancellationToken);
    Task<ILicense> GetLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken);
    Task UpdateLicense(
        ILicense license,
        string password,
        CancellationToken cancellationToken);
    Task DeleteLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken);
}
