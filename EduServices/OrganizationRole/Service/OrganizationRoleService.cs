using Core.Base.Service;
using EduRepository.OrganizationRoleRepository;
using EduRepository.PermissionsRepository;
using EduServices.OrganizationRole.Convertor;
using Model.Edu.OrganizationRole;
using Model.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.OrganizationRole.Service
{
    public class OrganizationRoleService(
        IOrganizationRoleRepository organizationRoleRepository,
        IOrganizationRoleConvertor convertor,
        IPermissionsRepository permissionsRepository
    ) : BaseService<IOrganizationRoleRepository, OrganizationRoleDbo, IOrganizationRoleConvertor>(organizationRoleRepository, convertor), IOrganizationRoleService
    {
        private readonly IPermissionsRepository _permissionsRepository = permissionsRepository;

        public bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles)
        {
            if (roles == null)
            {
                return false;
            }

            HashSet<PermissionsDbo> permissions = _permissionsRepository.GetEntities(false, x => x.Route.Route == route.Trim('/') && x.OrganizationRole.UserInOrganizations.Any(y => y.OrganizationId == organizationId) && x.OrganizationRole.UserInOrganizations.Any(y => y.UserId == userId) && roles.Contains(x.OrganizationRole.SystemIdentificator));
            return permissions.Count > 0;
        }
    }
}