using AdminService.Permissions.List.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Permissions.List.Convertor
{
    public interface IPermissionsListConvertor : IBaseListConvertor<PermissionsDbo, PermissionsListDto> { }
}
