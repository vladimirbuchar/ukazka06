using Core.Base.Service;
using EduServices.Permissions.Dto;
using Model.Tables.System;

namespace EduServices.Permissions.Service
{
    public interface IPermissionsService : IBaseService<PermissionsDbo, PermissionsCreateDto, PermissionsListDto, PermissionsDetailDto, PermissionsUpdateDto>
    {


    }
}
