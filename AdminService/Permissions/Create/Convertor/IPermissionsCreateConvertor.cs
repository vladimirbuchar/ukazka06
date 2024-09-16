using AdminService.Permissions.Create.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Permissions.Create.Convertor
{
    public interface IPermissionsCreateConvertor : IBaseCreateConvertor<PermissionsDbo, PermissionsCreateDto> { }
}
