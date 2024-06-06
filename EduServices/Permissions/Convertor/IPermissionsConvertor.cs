using Core.Base.Convertor;
using EduServices.Permissions.Dto;
using Model.Tables.System;

namespace EduServices.Permissions.Convertor
{
    public interface IPermissionsConvertor : IBaseConvertor<PermissionsDbo, PermissionsCreateDto, PermissionsListDto, PermissionsDetailDto, PermissionsUpdateDto> { }
}
