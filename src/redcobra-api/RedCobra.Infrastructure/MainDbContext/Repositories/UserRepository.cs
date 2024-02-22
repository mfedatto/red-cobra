using System.Data.Common;
using RedCobra.Domain.User;

namespace RedCobra.Infrastructure.MainDbContext.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbConnection _dbConnection;
    private readonly DbTransaction _dbTransaction;

    public UserRepository(
        DbConnection dbConnection,
        DbTransaction dbTransaction)
    {
        _dbConnection = dbConnection;
        _dbTransaction = dbTransaction;
    }
    
    public async Task<IEnumerable<IUser>> GetUsersList(
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email,
        int? skip,
        int? limit)
    {
        throw new NotImplementedException();
    }
    
    public async Task<int> GetUsersCount(
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IUser> AddUser(
        CancellationToken cancellationToken,
        IUser user,
        string password)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IUser> GetUser(
        CancellationToken cancellationToken,
        Guid userId)
    {
        throw new NotImplementedException();
    }
    
    public async Task UpdateUser(
        CancellationToken cancellationToken,
        IUser user,
        string password)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteUser(
        CancellationToken cancellationToken,
        Guid userId)
    {
        throw new NotImplementedException();
    }
}