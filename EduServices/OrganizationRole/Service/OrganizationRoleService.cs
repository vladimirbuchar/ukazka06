﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Service;
using Model.Edu.OrganizationRole;
using Model.System;
using Repository.OrganizationRoleRepository;
using Repository.PermissionsRepository;
using Services.OrganizationRole.Convertor;

namespace Services.OrganizationRole.Service
{
    public class OrganizationRoleService(
        IOrganizationRoleRepository organizationRoleRepository,
        IOrganizationRoleConvertor convertor,
        IPermissionsRepository permissionsRepository
    )
        : BaseService<IOrganizationRoleRepository, OrganizationRoleDbo, IOrganizationRoleConvertor>(organizationRoleRepository, convertor),
            IOrganizationRoleService
    {
        private readonly IPermissionsRepository _permissionsRepository = permissionsRepository;

        public bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles)
        {
            if (roles == null)
            {
                return false;
            }

            List<PermissionsDbo> permissions = _permissionsRepository
                .GetEntities(
                    false,
                    x =>
                        x.Route.Route == route.Trim('/')
                        && x.OrganizationRole.UserInOrganizations.Any(y => y.OrganizationId == organizationId)
                        && x.OrganizationRole.UserInOrganizations.Any(y => y.UserId == userId)
                        && roles.Contains(x.OrganizationRole.SystemIdentificator)
                )
                .Result;
            return permissions.Count > 0;
        }
    }
}
