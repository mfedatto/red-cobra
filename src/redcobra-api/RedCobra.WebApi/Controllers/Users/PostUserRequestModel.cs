namespace RedCobra.WebApi.Controllers.Users
{
    public record PostUserRequestModel(
        string Credentials,
        bool Admin,
        string FullName,
        string Email) { }
}
