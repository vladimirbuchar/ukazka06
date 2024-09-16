using AdminService.Permissions.List.Dto;
using Model.System;

namespace AdminService.Permissions.List.Convertor
{
    public class PermissionsListConvertor : IPermissionsListConvertor
    {
        public Task<List<PermissionsListDto>> ConvertToWebModel(List<PermissionsDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new PermissionsListDto()
                {
                    Id = x.Id,
                    OrganizationRole = x.OrganizationRole.SystemIdentificator,
                    Route = x.Route.Route
                })
                    .ToList()
            );
        }
    }
}
