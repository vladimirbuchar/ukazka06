using AdminService.Permissions.Update.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Permissions.Update.Convertor
{
    public interface IPermissionsUpdateConvertor : IBaseUpdateConvertor<PermissionsDbo, PermissionsUpdateDto> { }
}
