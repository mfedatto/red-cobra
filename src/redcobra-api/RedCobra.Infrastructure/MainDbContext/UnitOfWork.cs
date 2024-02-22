using System.Data;
using System.Data.Common;
using Npgsql;
using RedCobra.Domain.AppSettings;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.MainDbContext;
using RedCobra.Domain.User;
using RedCobra.Infrastructure.MainDbContext.Repositories;

namespace RedCobra.Infrastructure.MainDbContext;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DbConnection _dbConnection;
    private DbTransaction? _dbTransaction;
    private bool _disposed;

    public UnitOfWork(
        DatabaseConfig config)
    {
        _dbConnection = new NpgsqlConnection(
                new NpgsqlConnectionStringBuilder(
                        config.ConnectionString)
                    {
                        IncludeErrorDetail = config.IncludeErrorDetail
                    }
                    .ToString()
            );
    }
    
    public IUserRepository UserRepository => new UserRepository(_dbConnection, _dbTransaction);

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
