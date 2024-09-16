namespace HangfireApi.Configuration.Hangfire
{
    public class BasicAuthAuthorizationUser
    {
        public required string Login { get; set; }
        public required string PasswordClear { get; set; }
    }
}
