using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HangfireApi.Configuration.Hangfire
{
    public class BasicAuthAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly BasicAuthAuthorizationFilterOptions _options;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Přidáme IHttpContextAccessor jako závislost v konstruktoru
        public BasicAuthAuthorizationFilter([NotNull] BasicAuthAuthorizationFilterOptions options, IHttpContextAccessor httpContextAccessor)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public bool Authorize([NotNull] DashboardContext context)
        {
            // Použití IHttpContextAccessor k získání HttpContext
            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                return false;
            }

            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader == null || !authHeader.StartsWith("Basic "))
            {
                return Challenge(httpContext);
            }

            string encodedUsernamePassword = authHeader["Basic ".Length..].Trim();

            byte[] decodedBytes;
            try
            {
                decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
            }
            catch (FormatException)
            {
                return Challenge(httpContext); // neplatný Base64 řetězec
            }

            string usernamePassword = Encoding.UTF8.GetString(decodedBytes);

            int separatorIndex = usernamePassword.IndexOf(':');
            if (separatorIndex == -1)
            {
                return Challenge(httpContext); // nesprávný formát username:password
            }

            string username = usernamePassword[..separatorIndex];
            string password = usernamePassword[(separatorIndex + 1)..];

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Challenge(httpContext); // prázdné username nebo password
            }

            foreach (BasicAuthAuthorizationUser user in _options.Users)
            {
                if (
                    string.Equals(username, user.Login, _options.LoginCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase)
                    && string.Equals(password, user.PasswordClear)
                )
                {
                    return true;
                }
            }

            return Challenge(httpContext);
        }

        private bool Challenge(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            return false;
        }
    }
}