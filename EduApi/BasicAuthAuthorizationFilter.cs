using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EduApi
{
    public class BasicAuthAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly BasicAuthAuthorizationFilterOptions _options;

        public BasicAuthAuthorizationFilter([NotNull] BasicAuthAuthorizationFilterOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader == null || !authHeader.StartsWith("Basic "))
            {
                return Challenge(httpContext);
            }

            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            string usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int separatorIndex = usernamePassword.IndexOf(':');
            string username = usernamePassword.Substring(0, separatorIndex);
            string password = usernamePassword.Substring(separatorIndex + 1);

            foreach (var user in _options.Users)
            {
                if (string.Equals(username, user.Login, _options.LoginCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(password, user.PasswordClear))
                {
                    return true;
                }
            }

            return Challenge(httpContext);
        }

        private bool Challenge(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            return false;
        }
    }
}
