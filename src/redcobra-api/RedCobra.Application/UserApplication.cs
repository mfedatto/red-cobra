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
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email,
        int skip = 0,
        int? limit = null)
    {
        int total = await _service.GetUsersCount(
            cancellationToken,
            username,
            admin,
            fullName,
            email);
        
        return (await _service.GetUsersList(
            cancellationToken,
            username,
            admin,
            fullName,
            email,
            skip,
            limit))
            .WrapUp(
                skip,
                limit,
                total);
    }
    
    public async Task<IUser> AddUser(
        CancellationToken cancellationToken,
        IUser user,
        string password)
    {
        return await _service.AddUser(
            cancellationToken,
            user,
            password);
    }
    
    public async Task<IUser> GetUser(
        CancellationToken cancellationToken,
        Guid userId)
    {
        return await _service.GetUser(
            cancellationToken,
            userId);
    }
    
    public async Task UpdateUser(
        CancellationToken cancellationToken,
        IUser user,
        string password)
    {
        await _service.UpdateUser(
            cancellationToken,
            user,
            password);
    }
    
    public async Task DeleteUser(
        CancellationToken cancellationToken,
        Guid userId)
    {
        await _service.DeleteUser(
            cancellationToken,
            userId);
    }
}
