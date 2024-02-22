using Microsoft.Extensions.Logging;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.User;
using RedCobra.Domain.Wrappers;

namespace RedCobra.Application;

public class UserApplication : IUserApplication
{
    private readonly ILogger<UserApplication> _logger;
    private readonly IUserService _service;

    public UserApplication(
        ILogger<UserApplication> logger,
        IUserService service)
    {
        _logger = logger;
        _service = service;
    }
    
    public async Task<PagedListWrapper<IUser>> GetUsersList(
        string username,
        bool? admin,
        string fullName,
        string email,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        int total = await _service.GetUsersCount(
            username,
            admin,
            fullName,
            email,
            cancellationToken);
        
        return (await _service.GetUsersList(
            username,
            admin,
            fullName,
            email,
            skip,
            limit > 0
                ? limit
                : total - skip,
            cancellationToken))
            .WrapUp(
                skip,
                limit,
                total);
    }
    
    public async Task<IUser> AddUser(
        IUser user,
        string password,
        CancellationToken cancellationToken)
    {
        if (!await IsUsernameAvailable(
                user.Username,
                cancellationToken))
            throw new UsernameAlreadyInUseException();
        
        return await _service.AddUser(
            user,
            password,
            cancellationToken);
    }
    
    public async Task<IUser> GetUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        try
        {
            return (await _service.GetUser(
                userId,
                cancellationToken))!;
        }
        catch (ArgumentNullException)
        {
            throw new UserNotFoundException();
        }
        catch (InvalidOperationException)
        {
            throw new MultipleUsersFoundException();
        }
    }
    
    public async Task UpdateUser(
        IUser user,
        string password,
        CancellationToken cancellationToken)
    {
        await _service.UpdateUser(
            user,
            password,
            cancellationToken);
    }
    
    public async Task DeleteUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        await _service.DeleteUser(
            userId,
            cancellationToken);
    }

    private async Task<bool> IsUsernameAvailable(
        string username,
        CancellationToken cancellationToken)
    {
        return await _service.GetUsersCount(
            username,
            null,
            string.Empty,
            string.Empty,
            cancellationToken: cancellationToken) == 0;
    }
}
