namespace RedCobra.WebApi.Constants;

public static class RouteTemplates
{
    public static class Users_v1
    {
        public const string Controller = "v1/users";
        public const string GetUsersList = "";
        public const string PostUser = "";
        public const string GetUser = $"{{{NamedArgs.UserId}}}";
        public const string PutUser = $"{{{NamedArgs.UserId}}}";
        public const string DeleteUser = $"{{{NamedArgs.UserId}}}";
    }
    
    public static class Licenses_v1
    {
        public const string Controller = $"v1/users/{{{NamedArgs.UserId}}}/licenses";
        public const string GetLicensesList = "";
        public const string PostLicense = "";
        public const string GetLicense = $"{{{NamedArgs.LicenseId}}}";
        public const string PutLicense = $"{{{NamedArgs.LicenseId}}}";
        public const string DeleteLicense = $"{{{NamedArgs.LicenseId}}}";
    }
}
