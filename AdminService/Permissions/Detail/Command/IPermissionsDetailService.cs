using AdminService.Permissions.Detail.Dto;
using Core.Base.Command.Detail;
using Model.System;

namespace AdminService.Permissions.Detail.Command
{
    public interface IPermissionsDetailService : IBaseDetailCommand<PermissionsDbo, PermissionsDetailDto> { }
}
