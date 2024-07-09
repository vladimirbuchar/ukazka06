using Core.Base.Convertor;
using Model.System;
using Services.Permissions.Dto;

namespace Services.Permissions.Convertor
{
    public interface IPermissionsConvertor
        : IBaseConvertor<PermissionsDbo, PermissionsCreateDto, PermissionsListDto, PermissionsDetailDto, PermissionsUpdateDto> { }
}
