namespace RedCobra.Domain.User;

public class UserFactory
{
    public IUser Create(
        Guid UserId,
        string Username,
        bool Admin,
        string FullName,
        string Email)
    {
        return new User
        {
            UserId = UserId,
            Username = Username,
            Admin = Admin,
            FullName = FullName,
            Email = Email
        };
    }
}

file record User : IUser {
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public required bool Admin { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
}

