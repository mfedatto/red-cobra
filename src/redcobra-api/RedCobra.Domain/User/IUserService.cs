namespace RedCobra.Domain.User;

public interface IUserService
{
    Task<IEnumerable<IUser>> GetUsersList(
        string username,
        bool? admin,
        string fullName,
        string email,
        int skip,
        int limit,
        CancellationToken cancellationToken);
    Task<int> GetUsersCount(
        string username,
        bool? admin,
        string fullName,
        string email,
        CancellationToken cancellationToken);
    Task<IUser> AddUser(
        IUser user,
        string password,
        CancellationToken cancellationToken);
    Task<IUser?> GetUser(
        Guid userId,
        CancellationToken cancellationToken);
    Task UpdateUser(
        IUser user,
        string password,
        CancellationToken cancellationToken);
    Task DeleteUser(
        Guid userId,
        CancellationToken cancellationToken);
}
