namespace RedCobra.WebApi.Controllers.Users;

public record PostUserResponseModel(
    Guid UserId,
    string Username,
    bool Admin,
    string FullName,
    string Email) { }
