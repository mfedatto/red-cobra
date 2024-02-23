using Microsoft.Extensions.Logging;
using RedCobra.Domain.MainDbContext;
using RedCobra.Domain.User;

namespace RedCobra.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserFactory _userFactory;
    private readonly IUnitOfWork _uow;

    public UserService(
        ILogger<UserService> logger,
        UserFactory userFactory,
        IUnitOfWork uow)
    {
        _logger = logger;
        _userFactory = userFactory;
        _uow = uow;
    }
    
    public async Task<IEnumerable<IUser>> GetUsersList(
        string username,
        bool? admin,
        string fullName,
        string email,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        return await _uow.UserRepository.GetUsersList(
            username,
            admin,
            fullName,
            email,
            skip,
            limit,
            cancellationToken);
    }
    
    public async Task<int> GetUsersCount(
        string username,
        bool? admin,
        string fullName,
        string email,
        CancellationToken cancellationToken)
    {
        return await _uow.UserRepository.GetUsersCount(
            username,
            admin,
            fullName,
            email,
            cancellationToken);
    }
    
    public async Task<IUser> AddUser(
        IUser user,
        string password,
        CancellationToken cancellationToken)
    {
        IUser addingUser;

        if (!Guid.Empty.Equals(user.UserId))
        {
            addingUser = user;
        }
        else
        {
            addingUser = _userFactory.Create(
                Guid.NewGuid(),
                user.Username,
                user.Admin,
                user.FullName,
                user.Email);
        }
        
        await _uow.UserRepository.AddUser(
            addingUser,
            password,
            cancellationToken);

        return addingUser;
    }
    
    public async Task<IUser?> GetUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        return await _uow.UserRepository.GetUser(
            userId,
            cancellationToken);
    }
    
    public async Task UpdateUser(
        IUser user,
        string password,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        await _uow.UserRepository.DeleteUser(
            userId,
            cancellationToken);
    }
}
