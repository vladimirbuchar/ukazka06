using AdminService.Permissions.Create.Dto;
using Model.System;

namespace AdminService.Permissions.Create.Convertor
{
    public class PermissionsCreateConvertor : IPermissionsCreateConvertor
    {
        public Task<PermissionsDbo> ConvertToBussinessEntity(PermissionsCreateDto create, string culture)
        {
            return Task.FromResult(new PermissionsDbo() { RouteId = create.RouteId, OrganizationRoleId = create.OrganizationRoleId });
        }
    }
}
