using AdminService.Permissions.Create.Command;
using AdminService.Permissions.Create.Dto;
using AdminService.Permissions.Delete.Command;
using AdminService.Permissions.Detail.Command;
using AdminService.Permissions.List.Command;
using AdminService.Permissions.List.Dto;
using AdminService.Route.RouteCreate.Command;
using AdminService.Route.RouteCreate.Dto;
using AdminService.Route.RouteDetail.Command;
using Core.Base.Controller;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Command;
using SetupService.CheckUser.Command;
using SetupService.CheckUser.Dto;
using SetupService.CreateAdministratorUser.Command;
using SetupService.GetAllEndpoints.Command;
using SetupService.ImportDefaultPermissions.Dto;
using UserService.Role.RoleDetail.Command;

namespace SetupApi.Controllers.Setup
{
    [ApiExplorerSettings(GroupName = "Setup")]
    public class SetupController : BaseWebController
    {
        private readonly IRoleDetailService _roleDetailService;
        private readonly ICheckUserService _checkUserService;
        private readonly IGetAllEndpointsCommand _getAllEndpoints;
        private readonly IRouteDetailService _routeDetailService;
        private readonly IRouteCreateService _routeCreateService;
        private readonly IPermissionsListService _permissionsListService;
        private readonly IPermissionsDeleteService _permissionsDeleteService;
        private readonly IPermissionsDetailService _permissionsDetailService;
        private readonly IPermissionsCreateService _permissionsCreateService;
        private readonly IOrganizationRoleDetailService _organizationRoleDetailService;


        public SetupController(
            ILogger<SetupController> logger,
            ICreateAdministratorUserService createAdministratorUserService,
            IOrganizationRoleDetailService organizationRoleDetailService,
            ICheckUserService checkUserService,
            IGetAllEndpointsCommand getAllEndpoints,
            IRouteCreateService routeCreateService,
            IRouteDetailService routeDetailService,
            IPermissionsListService permissionsListService,
            IPermissionsDeleteService permissionsDeleteService,
            IPermissionsDetailService permissionsDetailService,
            IPermissionsCreateService permissionsCreateService,
            IRoleDetailService roleDetailService

        )
            : base(logger)
        {

            CreateAdministratorUserService = createAdministratorUserService;
            _roleDetailService = roleDetailService;
            _checkUserService = checkUserService;
            _getAllEndpoints = getAllEndpoints;
            _routeDetailService = routeDetailService;
            _routeCreateService = routeCreateService;
            _permissionsListService = permissionsListService;
            _permissionsDeleteService = permissionsDeleteService;
            _permissionsDetailService = permissionsDetailService;
            _permissionsCreateService = permissionsCreateService;
            _organizationRoleDetailService = organizationRoleDetailService;
        }

        public ICreateAdministratorUserService CreateAdministratorUserService { get; }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAdministratorUser()
        {
            try
            {
                Guid roleId = (await _roleDetailService.Execute(x => x.SystemIdentificator == UserRole.ADMINISTRATOR, [GetClientCulture()])).Id;
                return await SendResponse(await CreateAdministratorUserService.Execute(roleId));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> ImportDefaultPermissions([FromQuery] SetupLoginDto setupLogin, [FromQuery] bool delete = false)
        {
            try
            {
                if (await _checkUserService.Execute(setupLogin))
                {
                    if (delete)
                    {
                        List<PermissionsListDto> permissions = (await _permissionsListService.Execute()).Data;
                        foreach (PermissionsListDto permission in permissions)
                        {
                            _ = await _permissionsDeleteService.Execute(permission.Id, Guid.Empty);
                        }
                    }
                    using StreamReader r = new("organizationRoleConfig.json");
                    string json = r.ReadToEnd();
                    if (!string.IsNullOrEmpty(json))
                    {
                        List<PermissionsDto> items = JsonConvert.DeserializeObject<List<PermissionsDto>>(json);
                        foreach (PermissionsDto item in items)
                        {
                            foreach (string role in item.Roles)
                            {
                                string route = item.Route.Trim('/');
                                if (
                                    await _permissionsDetailService.Execute(x => x.Route.Route == route && x.OrganizationRole.SystemIdentificator == role, [GetClientCulture()])
                                    == null
                                )
                                {
                                    Guid? routeId = (await _routeDetailService.Execute(x => x.Route == route, [GetClientCulture()]))?.Id;
                                    if (routeId != null)
                                    {
                                        Guid roleId = (await _organizationRoleDetailService.Execute(x => x.SystemIdentificator == role, [GetClientCulture()])).Id;
                                        _ = await _permissionsCreateService.Execute(
                                            new PermissionsCreateDto()
                                            {
                                                RouteId = routeId.Value,
                                                OrganizationRoleId = roleId

                                            },
                                            GetLoggedUserId(),
                                            GetClientCulture()
                                        );
                                    }
                                }
                            }
                        }
                    }
                    return await SendResponse(new Result());
                }

                return await SendResponse(null);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> RegisterAllEndPoints([FromQuery] SetupLoginDto setupLogin)
        {
            try
            {
                if (await _checkUserService.Execute(setupLogin))
                {
                    List<string> endpoints = await _getAllEndpoints.Execute();
                    foreach (string endpoint in endpoints)
                    {
                        if (await _routeDetailService.Execute(x => x.Route == endpoint, [GetClientCulture()]) == null)
                        {
                            _ = await _routeCreateService.Execute(new RouteCreateDto()
                            {
                                Route = endpoint
                            }, GetLoggedUserId(), GetClientCulture());
                        }
                    }
                }
                return await SendResponse(true);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
