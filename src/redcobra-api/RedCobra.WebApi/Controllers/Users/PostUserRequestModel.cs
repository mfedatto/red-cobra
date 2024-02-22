namespace RedCobra.WebApi.Controllers.Users
{
    public record PostUserRequestModel(
        bool Admin,
        string FullName,
        string Email) { }
}
