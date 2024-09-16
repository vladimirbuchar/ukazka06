using Microsoft.Extensions.DependencyInjection;
using Services.Email.EmailDetail.Command;
using SystemServices.Email.EmailDetail.Command;
using SystemServices.Email.EmailDetail.Convertor;

namespace SystemServices
{
    public static class RegisterSystemService
    {
        public static void RegisterService(IServiceCollection service)
        {
            _ = service.AddScoped<IEmailDetailService, EmailDetailService>();
            _ = service.AddScoped<IEmailDetailConvertor, EmailDetailConvertor>();
        }
    }
}
