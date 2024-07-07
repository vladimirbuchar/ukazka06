using System;
using System.Collections.Generic;
using Core.Base.Service;

namespace Services.OrganizationRole.Service
{
    public interface IOrganizationRoleService : IBaseService
    {
        bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles);
    }
}
