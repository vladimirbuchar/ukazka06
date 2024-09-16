using Microsoft.Extensions.DependencyInjection;
using SetupService.CheckUser.Command;
using SetupService.CreateAdministratorUser.Command;
using SetupService.GetAllEndpoints.Command;

namespace SetupService
{
    public static class RegisterSetupService
    {
        public static void RegisterService(IServiceCollection service)
        {
            RegistrationSetup(service);
        }

        private static void RegistrationSetup(this IServiceCollection service)
        {
            _ = service.AddScoped<ICreateAdministratorUserService, CreateAdministratorUserService>();
            _ = service.AddScoped<IGetAllEndpointsCommand, GetAllEndpointsCommand>();
            _ = service.AddScoped<ICheckUserService, CheckUserService>();
        }
    }
}
