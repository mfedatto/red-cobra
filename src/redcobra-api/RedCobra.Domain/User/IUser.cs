namespace RedCobra.Domain.User;

public interface IUser
{
    Guid UserId {get;}
    string Username {get;}
    bool Admin {get;}
    string FullName {get;}
    string Email {get;}
}