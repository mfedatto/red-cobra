using Microsoft.Extensions.Logging;
using RedCobra.Domain.Licenses;

namespace RedCobra.Application;

public class LicenseApplication : ILicenseApplication
{
    private readonly ILogger<LicenseApplication> _logger;
    private readonly ILicenseService _service;

    public LicenseApplication(
        ILogger<LicenseApplication> logger,
        ILicenseService service)
    {
        _logger = logger;
        _service = service;
    }
    
    public async Task<IEnumerable<ILicense>> GetUserLicensesList(
        Guid userId,
        bool? aCategory,
        bool? bCategory,
        bool includeExpired,
        CancellationToken cancellationToken)
    {
        return await _service.GetUserLicensesList(
            userId,
            aCategory,
            bCategory,
            includeExpired,
            cancellationToken);
    }

    public async Task<ILicense> AddLicense(
        ILicense license,
        CancellationToken cancellationToken)
    {
        return await _service.AddLicense(
            license,
            cancellationToken);
    }

    public async Task<ILicense> GetLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        return await _service.GetLicense(
            userId,
            licenseId,
            cancellationToken);
    }

    public async Task UpdateLicense(
        ILicense license,
        string password,
        CancellationToken cancellationToken)
    {
        await _service.UpdateLicense(
            license,
            password,
            cancellationToken);
    }

    public async Task DeleteLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        await _service.DeleteLicense(
            userId,
            licenseId,
            cancellationToken);
    }
}
