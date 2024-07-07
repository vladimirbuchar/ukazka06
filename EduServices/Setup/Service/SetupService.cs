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
    )
        : BaseService(),
            ISetupService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly IRouteRepository _routeRepository = routeRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly IPermissionsRepository _permissionsRepository = permissionsRepository;
        private readonly IEnumerable<EndpointDataSource> _endpointSources = endpointSources;

        public Result CreateAdministratorUser()
        {
            UserDbo admin = _userRepository.GetEntity(false, x => x.UserEmail == _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value);
            if (admin == null)
            {
                _ = _userRepository.CreateEntity(new UserDbo()
                {
                    UserEmail = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value,
                    UserPassword = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_PASSWORD).Value.GetHashString(),
                    Person = new PersonDbo()
                    {

                    },
                    UserRoleId = _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.ADMINISTRATOR).Id,
                    IsActive = true

                }, Guid.Empty);
            }
            return new Result();
        }

        public Result ImportDefaultPermitions(bool delete)
        {
            if (delete)
            {
                HashSet<PermissionsDbo> permissions = _permissionsRepository.GetEntities(false);
                foreach (PermissionsDbo permission in permissions)
                {
                    _permissionsRepository.DeleteEntity(permission, Guid.Empty);
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
                    if (_permissionsRepository.GetEntity(false, x => x.Route.Route == route && x.OrganizationRole.SystemIdentificator == role) == null)
                    {
                        Guid? routeId = _routeRepository.GetEntity(false, x => x.Route == route)?.Id;
                        if (routeId != null)
                        {
                            Guid roleId = _organizationRoleRepository.GetEntity(false, x => x.SystemIdentificator == role).Id;
                            _ = _permissionsRepository.CreateEntity(new PermissionsDbo()
                            {
                                RouteId = routeId.Value,
                                OrganizationRoleId = roleId
                            }, Guid.Empty);
                        }
                    }
                }
            }
            return new Result();
        }

        public Result RegisterAllEndpoints()
        {
            List<string> endpoints = _endpointSources
               .SelectMany(es => es.Endpoints)
               .OfType<RouteEndpoint>().Select(x => x.RoutePattern.RawText).ToList();
            foreach (string endpoint in endpoints)
            {
                if (_routeRepository.GetEntity(false, x => x.Route == endpoint) == null)
                {
                    _ = _routeRepository.CreateEntity(new RouteDbo()
                    {
                        Route = endpoint,
                    }, Guid.Empty);
                }

            }
            return new Result();
        }
        public bool CheckUser(SetupLoginDto setupLogin)
        {
            return _userRepository.GetEntity(false, x => x.UserEmail == setupLogin.UserEmail && x.UserPassword == setupLogin.Password.GetHashString() && x.IsActive == true && x.AllowCLassicLogin == true)?.UserRole?.SystemIdentificator == UserRole.ADMINISTRATOR;
        }

    }

}
