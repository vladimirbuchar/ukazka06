using Core.Base.Service;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationRole.Service
{
    public interface IOrganizationRoleService : IBaseService
    {
        bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles);
    }
}
