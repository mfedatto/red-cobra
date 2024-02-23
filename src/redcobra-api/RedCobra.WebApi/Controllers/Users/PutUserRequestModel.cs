namespace RedCobra.WebApi.Controllers.Users;

public record PutUserRequestModel(
    string Credentials,
    bool Admin,
    string FullName,
    string Email) { }
