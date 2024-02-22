using RedCobra.Domain.Wrappers;

namespace RedCobra.Domain.User;

public interface IUserApplication
{
    Task<PagedListWrapper<IUser>> GetUsersList(
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email,
        int skip,
        int? limit);
    Task<IUser> AddUser(
        CancellationToken cancellationToken,
        IUser user,
        string password);
    Task<IUser> GetUser(
        CancellationToken cancellationToken,
        Guid userId);
    Task UpdateUser(
        CancellationToken cancellationToken,
        IUser user,
        string password);
    Task DeleteUser(
        CancellationToken cancellationToken,
        Guid userId);
}
