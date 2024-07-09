using Core.Base.Request;
using Core.Base.Service;
using Model.System;
using Services.Permissions.Dto;

namespace Services.Permissions.Service
{
    public interface IPermissionsService
        : IBaseService<PermissionsDbo, PermissionsCreateDto, PermissionsListDto, PermissionsDetailDto, PermissionsUpdateDto, FilterRequest> { }
}
