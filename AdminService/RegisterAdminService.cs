using AdminService.Permissions.Create.Command;
using AdminService.Permissions.Create.Convertor;
using AdminService.Permissions.Create.Validator;
using AdminService.Permissions.Delete.Command;
using AdminService.Permissions.Detail.Command;
using AdminService.Permissions.Detail.Convertor;
using AdminService.Permissions.List.Command;
using AdminService.Permissions.List.Convertor;
using AdminService.Permissions.Restore.Command;
using AdminService.Permissions.Update.Command;
using AdminService.Permissions.Update.Convertor;
using AdminService.Permissions.Update.Validator;
using AdminService.Route.RouteCreate.Command;
using AdminService.Route.RouteCreate.Convertor;
using AdminService.Route.RouteCreate.Validator;
using AdminService.Route.RouteDelete.Command;
using AdminService.Route.RouteDetail.Command;
using AdminService.Route.RouteDetail.Convertor;
using AdminService.Route.RouteList.Command;
using AdminService.Route.RouteList.Convertor;
using AdminService.Route.RouteRestore.Command;
using AdminService.Route.RouteUpdate.Command;
using AdminService.Route.RouteUpdate.Convertor;
using AdminService.Route.RouteUpdate.Validator;
using Microsoft.Extensions.DependencyInjection;
using Repository.Permissions;
using Repository.Route;

namespace AdminService
{
    public static class RegisterAdminService
    {
        public static void RegisterService(IServiceCollection service)
        {
            RegistrationRoute(service);
            RegistrationPermissions(service);
        }

        private static void RegistrationRoute(IServiceCollection service)
        {
            _ = service.AddScoped<IRouteRepository, RouteRepository>();
            _ = service.AddScoped<IRouteCreateConvertor, RouteCreateConvertor>();
            _ = service.AddScoped<IRouteCreateService, RouteCreateService>();
            _ = service.AddScoped<IRouteCreateValidator, RouteCreateValidator>();
            _ = service.AddScoped<IRouteDeleteService, RouteDeleteService>();
            _ = service.AddScoped<IRouteDetailConvertor, RouteDetailConvertor>();
            _ = service.AddScoped<IRouteDetailService, RouteDetailService>();
            _ = service.AddScoped<IRouteListConvertor, RouteListConvertor>();
            _ = service.AddScoped<IRouteListService, RouteListService>();
            _ = service.AddScoped<IRouteRestoreService, RouteRestoreService>();
            _ = service.AddScoped<IRouteUpdateConvertor, RouteUpdateConvertor>();
            _ = service.AddScoped<IRouteUpdateService, RouteUpdateService>();
            _ = service.AddScoped<IRouteUpdateValidator, RouteUpdateValidator>();
        }

        private static void RegistrationPermissions(IServiceCollection service)
        {
            _ = service.AddScoped<IPermissionsRepository, PermissionsRepository>();
            _ = service.AddScoped<IPermissionsCreateService, PermissionsCreateService>();
            _ = service.AddScoped<IPermissionsListService, PermissionsListService>();
            _ = service.AddScoped<IPermissionsDetailService, PermissionsDetailService>();
            _ = service.AddScoped<IPermissionsUpdateService, PermissionsUpdateService>();
            _ = service.AddScoped<IPermissionsDeleteService, PermissionsDeleteService>();
            _ = service.AddScoped<IPermissionsRestoreService, PermissionsRestoreService>();
            _ = service.AddScoped<IPermissionsCreateValidator, PermissionsCreateValidator>();
            _ = service.AddScoped<IPermissionsUpdateValidator, PermissionsUpdateValidator>();
            _ = service.AddScoped<IPermissionsCreateConvertor, PermissionsCreateConvertor>();
            _ = service.AddScoped<IPermissionsUpdateConvertor, PermissionsUpdateConvertor>();
            _ = service.AddScoped<IPermissionsListConvertor, PermissionsListConvertor>();
            _ = service.AddScoped<IPermissionsDetailConvertor, PermissionsDetailConvertor>();
        }
    }

}
