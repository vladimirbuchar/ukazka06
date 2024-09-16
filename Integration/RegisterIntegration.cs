using Integration.HttpClient;
using Integration.ImagePng;
using Integration.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Integration
{
    public static class RegisterIntegration
    {
        public static void Register(IServiceCollection service)
        {
            _ = service.AddScoped<IHttpClientIntegration, HttpClientIntegration>();
            _ = service.AddScoped<IImagePngIntegration, ImagePngIntegration>();
            _ = service.AddScoped<IMailKitIntegration, MailKitIntegration>();

        }
    }
}
