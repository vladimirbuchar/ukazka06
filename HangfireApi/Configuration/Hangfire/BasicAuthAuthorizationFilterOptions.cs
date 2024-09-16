namespace HangfireApi.Configuration.Hangfire
{
    public class BasicAuthAuthorizationFilterOptions
    {
        public bool SslRedirect { get; set; }
        public bool RequireSsl { get; set; }
        public bool LoginCaseSensitive { get; set; }
        public required BasicAuthAuthorizationUser[] Users { get; set; }
    }
}
