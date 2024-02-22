namespace RedCobra.WebApi.Controllers.Users
{
    public record PutUserRequestModel(
        bool Admin,
        string FullName,
        string Email) { }
}
