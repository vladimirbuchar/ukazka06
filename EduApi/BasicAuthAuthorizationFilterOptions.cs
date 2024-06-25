namespace EduApi
{
    public class BasicAuthAuthorizationFilterOptions
    {
        public bool SslRedirect { get; set; }
        public bool RequireSsl { get; set; }
        public bool LoginCaseSensitive { get; set; }
        public BasicAuthAuthorizationUser[] Users { get; set; }
    }
}
