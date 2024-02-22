namespace RedCobra.Domain.User;

public interface IUserService
{
    Task<IEnumerable<IUser>> GetUsersList(
        CancellationToken cancellationToken,
        string? username,
        bool? admin,
        string? fullName,
        string? email,
        int? skip,
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
