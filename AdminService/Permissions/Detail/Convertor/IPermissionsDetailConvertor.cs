using AdminService.Permissions.Detail.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Permissions.Detail.Convertor
{
    public interface IPermissionsDetailConvertor : IBaseDetailConvertor<PermissionsDbo, PermissionsDetailDto> { }
}
