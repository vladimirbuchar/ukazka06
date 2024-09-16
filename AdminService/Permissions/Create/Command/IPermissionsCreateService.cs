using AdminService.Permissions.Create.Dto;
using Core.Base.Command.Create;
using Model.System;

namespace AdminService.Permissions.Create.Command
{
    public interface IPermissionsCreateService : IBaseCreateCommand<PermissionsDbo, PermissionsCreateDto> { }
}
