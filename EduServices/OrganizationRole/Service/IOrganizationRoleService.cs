using Core.Base.Service;
using System;
using System.Collections.Generic;

namespace Services.OrganizationRole.Service
{
    public interface IOrganizationRoleService : IBaseService
    {
        bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles);
    }
}
