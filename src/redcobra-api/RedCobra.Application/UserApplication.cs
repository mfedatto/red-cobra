using RedCobra.Domain.User;

namespace RedCobra.Application;

public class UserApplication : IUserApplication
{
    public async Task<IEnumerable<IUser>> GetUsers(
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
