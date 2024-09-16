using AdminService.Permissions.Detail.Dto;
using Model.System;

namespace AdminService.Permissions.Detail.Convertor
{
    public class PermissionsDetailConvertor : IPermissionsDetailConvertor
    {
        public Task<PermissionsDetailDto> ConvertToWebModel(PermissionsDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new PermissionsDetailDto()
                {
                    Id = detail.Id,
                    OrganizationRole = detail.OrganizationRole.SystemIdentificator,
                    Route = detail.Route.Route
                }
            );
        }
    }
}
