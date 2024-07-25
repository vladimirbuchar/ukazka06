using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Model.Edu.Person;
using Model.Edu.User;
using Model.System;
using Newtonsoft.Json;
using Repository.OrganizationRoleRepository;
using Repository.PermissionsRepository;
using Repository.RoleRepository;
using Repository.RouteRepository;
using Repository.UserRepository;
using Services.Setup.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Setup.Service
{
    public class SetupService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IConfiguration configuration,
        IRouteRepository routeRepository,
        IOrganizationRoleRepository organizationRoleRepository,
        IPermissionsRepository permissionsRepository,
        IEnumerable<EndpointDataSource> endpointSources
    ) : BaseService(), ISetupService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly IRouteRepository _routeRepository = routeRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly IPermissionsRepository _permissionsRepository = permissionsRepository;
        private readonly IEnumerable<EndpointDataSource> _endpointSources = endpointSources;

        public async Task<Result> CreateAdministratorUser()
        {
            UserDbo admin = await _userRepository.GetEntity(
                false,
                x => x.UserEmail == _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value
            );
            if (admin == null)
            {
                _ = await _userRepository.CreateEntity(
                    new UserDbo()
                    {
                        UserEmail = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value,
                        UserPassword = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_PASSWORD).Value.GetHashString(),
                        Person = new PersonDbo() { },
                        UserRoleId = (await _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.ADMINISTRATOR)).Id,
                        IsActive = true
                    },
                    Guid.Empty
                );
            }
            return new Result();
        }

        public async Task<Result> ImportDefaultPermitions(bool delete)
        {
            if (delete)
            {
                List<PermissionsDbo> permissions = await _permissionsRepository.GetEntities(false);
                foreach (PermissionsDbo permission in permissions)
                {
                    await _permissionsRepository.DeleteEntity(permission, Guid.Empty);
                }
            }
            using StreamReader r = new("organizationRoleConfig.json");
            string json = r.ReadToEnd();
            List<Permissions> items = JsonConvert.DeserializeObject<List<Permissions>>(json);
            foreach (Permissions item in items)
            {
                foreach (string role in item.Roles)
                {
                    string route = item.Route.Trim('/');
                    if (
                        await _permissionsRepository.GetEntity(false, x => x.Route.Route == route && x.OrganizationRole.SystemIdentificator == role) == null
                    )
                    {
                        Guid? routeId = (await _routeRepository.GetEntity(false, x => x.Route == route))?.Id;
                        if (routeId != null)
                        {
                            Guid roleId = (await _organizationRoleRepository.GetEntity(false, x => x.SystemIdentificator == role)).Id;
                            _ = await _permissionsRepository.CreateEntity(
                                new PermissionsDbo() { RouteId = routeId.Value, OrganizationRoleId = roleId },
                                Guid.Empty
                            );
                        }
                    }
                }
            }
            return new Result();
        }

        public async Task<Result> RegisterAllEndpoints()
        {
            List<string> endpoints = _endpointSources
                .SelectMany(es => es.Endpoints)
                .OfType<RouteEndpoint>()
                .Select(x => x.RoutePattern.RawText)
                .ToList();
            foreach (string endpoint in endpoints)
            {
                if (await _routeRepository.GetEntity(false, x => x.Route == endpoint) == null)
                {
                    _ = await _routeRepository.CreateEntity(new RouteDbo() { Route = endpoint, }, Guid.Empty);
                }
            }
            return new Result();
        }

        public async Task<bool> CheckUser(SetupLoginDto setupLogin)
        {
            UserDbo user = await _userRepository
                    .GetEntity(
                        false,
                        x =>
                            x.UserEmail == setupLogin.UserEmail
                            && x.UserPassword == setupLogin.Password.GetHashString()
                            && x.IsActive == true
                            && x.AllowCLassicLogin == true
                    );
            return
                    user?.UserRole?.SystemIdentificator == UserRole.ADMINISTRATOR;
        }


    }
}
