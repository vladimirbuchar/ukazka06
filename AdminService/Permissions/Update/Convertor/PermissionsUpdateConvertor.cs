using AdminService.Permissions.Update.Dto;
using Model.System;

namespace AdminService.Permissions.Update.Convertor
{
    public class PermissionsUpdateConvertor : IPermissionsUpdateConvertor
    {
        public Task<PermissionsDbo> ConvertToBussinessEntity(PermissionsUpdateDto update, PermissionsDbo entity, string culture)
        {
            entity.RouteId = update.RouteId;
            entity.OrganizationRoleId = update.OrganizationRoleId;
            return Task.FromResult(entity);
        }
    }
}
