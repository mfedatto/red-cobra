namespace RedCobra.WebApi.Controllers.Users;

public record PostUserRequestModel(
    Guid? UserId,
    string Credentials,
    bool Admin,
    string FullName,
    string Email) { }
