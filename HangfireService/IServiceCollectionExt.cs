using Microsoft.Extensions.DependencyInjection;

namespace HangfireService
{
    public static class RegisterHangfireService
    {
        public static void RegisterHangfireJob(this IServiceCollection service)
        {
            //_ = service.AddScoped<SendEmailJob>();
        }
    }
}
