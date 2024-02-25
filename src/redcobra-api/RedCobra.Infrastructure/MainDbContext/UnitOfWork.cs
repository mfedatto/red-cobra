using System.Data;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using RedCobra.Domain.AppSettings;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.Licenses;
using RedCobra.Domain.MainDbContext;
using RedCobra.Domain.User;
using RedCobra.Infrastructure.MainDbContext.Repositories;

namespace RedCobra.Infrastructure.MainDbContext;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly DbConnection _dbConnection;
    private DbTransaction? _dbTransaction;
    private bool _disposed;

    public UnitOfWork(
        ILogger<UnitOfWork> logger,
        DatabaseConfig config,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _dbConnection = new NpgsqlConnection(
                new NpgsqlConnectionStringBuilder(
                        config.ConnectionString)
                    {
                        IncludeErrorDetail = config.IncludeErrorDetail
                    }
                    .ToString()
            );
    }
    
    public DbConnection Connection => _dbConnection;
    public DbTransaction? Transaction => _dbTransaction;
    
    public IUserRepository UserRepository => _serviceProvider.GetService<IUserRepository>()!;
    public ILicenseRepository LicenseRepository => _serviceProvider.GetService<ILicenseRepository>()!;

    public async Task BeginTransactionAsync()
    {
        if (_dbTransaction is not null) throw new ConnectionInUseByOtherTransactionException();
        if (!ConnectionState.Open.Equals(_dbConnection.State)) await _dbConnection.OpenAsync();

        _dbTransaction = await _dbConnection.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_dbTransaction is null) throw new ConnectionWithoutTransactionException();

        await _dbTransaction.CommitAsync();
        await _dbTransaction.DisposeAsync();

        _dbTransaction = null;
    }

    public async Task RollbackAsync()
    {
        await _dbTransaction?.RollbackAsync()!;
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _dbTransaction?.Dispose();
            _dbConnection.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}
