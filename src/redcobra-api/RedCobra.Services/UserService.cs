using RedCobra.Domain.User;

namespace RedCobra.Services;

public class UserService : IUserService
{
    public async Task<IEnumerable<IUser>> GetUsersList(
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email,
        int? skip = 0,
        int? limit = null)
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
