using Core.Base.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.OrganizationRole.Service
{
    public interface IOrganizationRoleService : IBaseService
    {
        Task<bool> CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles);
    }
}
