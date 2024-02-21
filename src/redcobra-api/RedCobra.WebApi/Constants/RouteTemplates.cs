namespace RedCobra.WebApi.Constants;

public static class RouteTemplates
{
    public static class Users_v1
    {
        public const string Version = "v1";
        public const string Controller = "users";
        public const string GetUsersList = "";
        public const string PostUser = "";
        public const string GetUser = $"{{{NamedArgs.UserId}}}";
        public const string PutUser = $"{{{NamedArgs.UserId}}}";
        public const string DeleteUser = $"{{{NamedArgs.UserId}}}";
    }
}
