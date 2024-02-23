namespace RedCobra.WebApi.Controllers.Users;

public record GetUserResponseModel(
    Guid UserId,
    string Username,
    bool Admin,
    string FullName,
    string Email) { }
