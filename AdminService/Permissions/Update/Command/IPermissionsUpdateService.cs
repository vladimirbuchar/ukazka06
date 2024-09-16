using AdminService.Permissions.Update.Dto;
using Core.Base.Command.Update;
using Model.System;

namespace AdminService.Permissions.Update.Command
{
    public interface IPermissionsUpdateService : IBaseUpdateCommand<PermissionsDbo, PermissionsUpdateDto> { }
}
