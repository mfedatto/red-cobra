using System.Data.Common;
using Dapper;
using Microsoft.Extensions.Logging;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.Extensions;
using RedCobra.Domain.Licenses;

namespace RedCobra.Infrastructure.MainDbContext.Repositories;

public class LicenseRepository : ILicenseRepository
{
    private readonly ILogger<LicenseRepository> _logger;
    private readonly DbConnection _dbConnection;
    private readonly DbTransaction _dbTransaction;
    private readonly LicenseFactory _factory;

    public LicenseRepository(
        ILogger<LicenseRepository> logger,
        DbConnection dbConnection,
        DbTransaction dbTransaction,
        LicenseFactory factory)
    {
        _logger = logger;
        _dbConnection = dbConnection;
        _dbTransaction = dbTransaction;
        _factory = factory;
    }

    public async Task<IEnumerable<ILicense>> GetUserLicensesList(
        Guid userId,
        bool? aCategory,
        bool? bCategory,
        bool includeExpired,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        return (await _dbConnection.QueryAsync<LicenseRow>(
                """
                SELECT *
                FROM Licenses
                WHERE
                    UserId = @UserId::uuid AND
                    (@ACategory IS NULL OR ACategory = @ACategory) AND
                    (@BCategory IS NULL OR BCategory = @BCategory) AND
                    (@IncludeExpired OR ExpirationDate < @ExpirationDateLimit::date)
                ORDER BY LicenseNumber ASC, ExpirationDate DESC, IssueDate ASC;
                """,
                new
                {
                    UserId = userId,
                    ACategory = aCategory,
                    BCategory = bCategory,
                    IncludeExpired = includeExpired,
                    ExpirationDateLimit = DateTime.Now
                        .ClearTime()
                        .ToString("yyyy-MM-dd")
                },
                _dbTransaction))
            .Select(row => _factory.Create(
                row.LicenseId,
                row.LicenseNumber,
                row.UserId,
                row.ExpirationDate.ClearTime(),
                row.ACategory,
                row.BCategory,
                row.DateOfBirth.ClearTime(),
                row.LicenseFileId,
                row.Issuer,
                row.IssueDate?.ClearTime()
            ));
    }
    
    public async Task AddLicense(
        ILicense license,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        await _dbConnection.ExecuteAsync(
            """
            INSERT INTO Licenses (LicenseId, LicenseNumber, UserId, ExpirationDate, ACategory, BCategory, DateOfBirth, LicenseFileId, Issuer, IssueDate)
            VALUES (@LicenseId::uuid, @LicenseNumber, @UserId::uuid, @ExpirationDate::date, @ACategory, @BCategory, @DateOfBirth::date, @LicenseFileId, @Issuer, @IssueDate::date);
            """,
            license,
            transaction: _dbTransaction);
    }

    public async Task<ILicense> GetLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLicense(
        ILicense license,
        string password,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteLicense(
        Guid userId,
        Guid licenseId,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        await _dbConnection.ExecuteAsync(
            """
            DELETE FROM Licenses
            WHERE
                LicenseId = @LicenseId AND
                UserId = @UserId;
            """,
            new
            {
                LicenseId = licenseId,
                UserId = userId
            },
            transaction: _dbTransaction);
    }
}

file record LicenseRow
{
    public Guid LicenseId { get; init; }
    public string LicenseNumber { get; init; }
    public Guid UserId { get; init; }
    public DateTime ExpirationDate { get; init; }
    public bool ACategory { get; init; }
    public bool BCategory { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Guid? LicenseFileId { get; init; }
    public string? Issuer { get; init; }
    public DateTime? IssueDate { get; init; }
}
