using Microsoft.Extensions.Logging;
using RedCobra.Domain.Licenses;
using RedCobra.Domain.MainDbContext;

namespace RedCobra.Services;

public class LicenseService : ILicenseService
{
    private readonly ILogger<LicenseService> _logger;
    private readonly IUnitOfWork _uow;

    public LicenseService(
        ILogger<LicenseService> logger,
        IUnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }
    
    public async Task<IEnumerable<ILicense>> GetUserLicensesList(
        Guid userId,
        bool? aCategory,
        bool? bCategory,
        bool includeExpired,
        CancellationToken cancellationToken)
    {
        return await _uow.LicenseRepository.GetUserLicensesList(
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
        await _uow.LicenseRepository.AddLicense(
            license,
            cancellationToken);
        
        return license;
    }

    public async Task<ILicense> GetLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        return await _uow.LicenseRepository.GetLicense(
            userId,
            licenseId,
            cancellationToken);
    }

    public async Task UpdateLicense(
        ILicense license,
        string password,
        CancellationToken cancellationToken)
    {
        await _uow.LicenseRepository.UpdateLicense(
            license,
            password,
            cancellationToken);
    }

    public async Task DeleteLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        await _uow.LicenseRepository.DeleteLicense(
            userId,
            licenseId,
            cancellationToken);
    }
}
