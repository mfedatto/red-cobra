﻿using System.Data.Common;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using RedCobra.Domain.Exceptions;
using RedCobra.Domain.Extensions;
using RedCobra.Domain.User;

namespace RedCobra.Infrastructure.MainDbContext.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly DbConnection _dbConnection;
    private readonly DbTransaction _dbTransaction;
    private readonly UserFactory _factory;

    public UserRepository(
        ILogger<UserRepository> logger,
        DbConnection dbConnection,
        DbTransaction dbTransaction,
        UserFactory factory)
    {
        _logger = logger;
        _dbConnection = dbConnection;
        _dbTransaction = dbTransaction;
        _factory = factory;
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
        cancellationToken.ThrowIfClientClosedRequest();

        return (await _dbConnection.QueryAsync<UserRow>(
                """
                SELECT *
                FROM Users
                WHERE
                    (@Username = '' OR LOWER(Username) ~ @Username) AND
                    (@FullName = '' OR LOWER(FullName) ~ @FullName) AND
                    (@Email = '' OR LOWER(Email) ~ @Email) AND
                    (@Admin IS NULL OR Admin = @Admin)
                ORDER BY Username
                OFFSET @Skip
                LIMIT @Limit;
                """,
                new
                {
                    Username = (username ?? string.Empty).ToLower(),
                    FullName = (fullName ?? string.Empty).ToLower(),
                    Email = (email ?? string.Empty).ToLower(),
                    Admin = admin,
                    Skip = skip,
                    Limit = limit
                },
                _dbTransaction))
            .Select(row => _factory.Create(
                    row.UserId,
                    row.Username,
                    row.Admin,
                    row.FullName!,
                    row.Email!
                ));
    }
    
    public async Task<int> GetUsersCount(
        string username,
        bool? admin,
        string fullName,
        string email,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        return await _dbConnection.ExecuteScalarAsync<int>(
                """
                SELECT COUNT(*)
                FROM Users
                WHERE
                    (@Username = '' OR LOWER(Username) ~ @Username) AND
                    (@FullName = '' OR LOWER(FullName) ~ @FullName) AND
                    (@Email = '' OR LOWER(Email) ~ @Email) AND
                    (@Admin IS NULL OR Admin = @Admin);
                """,
                new
                {
                    Username = (username ?? string.Empty).ToLower(),
                    FullName = (fullName ?? string.Empty).ToLower(),
                    Email = (email ?? string.Empty).ToLower(),
                    Admin = admin
                },
                _dbTransaction);
    }
    
    public async Task AddUser(
        IUser user,
        string passwordSalt,
        string passwordHash,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        await _dbConnection.ExecuteAsync(
            """
            INSERT INTO Users (UserId, Username, PasswordHash, PasswordSalt, Admin, FullName, Email)
            VALUES (@UserId, @Username, @PasswordHash, @PasswordSalt, @Admin, @FullName, @Email);
            """,
            new UserRow
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Admin = user.Admin,
                FullName = user.FullName!,
                Email = user.Email!
            },
            _dbTransaction);
    }
    
    public async Task<IUser?> GetUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        return (await _dbConnection.QueryAsync<UserRow>(
                """
                SELECT *
                FROM Users
                WHERE
                    UserId = @UserId::uuid;
                """,
                new
                {
                    UserId = userId
                },
                _dbTransaction))
            .Select(row => _factory.Create(
                row.UserId,
                row.Username,
                row.Admin,
                row.FullName!,
                row.Email!
            ))
            .SingleOrDefault();
    }
    
    public async Task UpdateUser(
        IUser user,
        string passwordSalt,
        string passwordHash,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        await _dbConnection.ExecuteAsync(
            """
            UPDATE Users
            SET
                UserId = @UserId::uuid,
                Username = @Username,
                PasswordHash = @PasswordHash,
                PasswordSalt = @PasswordSalt,
                Admin = @Admin,
                FullName = @FullName,
                Email = @Email
            WHERE UserId = @UserId;
            """,
            new UserRow
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Admin = user.Admin,
                FullName = user.FullName!,
                Email = user.Email!
            },
            _dbTransaction);
    }
    
    public async Task DeleteUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfClientClosedRequest();

        await _dbConnection.ExecuteAsync(
            """
            DELETE FROM Users
            WHERE UserId = @UserId;
            """,
            new
            {
                UserId = userId
            },
            transaction: _dbTransaction);
    }
}

file record UserRow {
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public required string PasswordHash { get; init; }
    public required string PasswordSalt { get; init; }
    public required bool Admin { get; init; }
    public string? FullName { get; init; }
    public string? Email { get; init; }
}
