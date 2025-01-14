﻿namespace RedCobra.Domain.User;

public interface IUserRepository
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
    Task AddUser(
        IUser user,
        string passwordSalt,
        string passwordHash,
        CancellationToken cancellationToken);
    Task<IUser?> GetUser(
        Guid userId,
        CancellationToken cancellationToken);
    Task UpdateUser(
        IUser user,
        string passwordSalt,
        string passwordHash,
        CancellationToken cancellationToken);
    Task DeleteUser(
        Guid userId,
        CancellationToken cancellationToken);
}
