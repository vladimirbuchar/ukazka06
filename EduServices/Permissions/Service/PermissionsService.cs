using Core.Base.Service;
using EduRepository.PermissionsRepository;
using EduServices.Permissions.Convertor;
using EduServices.Permissions.Dto;
using EduServices.Permissions.Validator;
using Model.Tables.System;

namespace EduServices.Permissions.Service
{
    public class PermissionsService(
        IPermissionsRepository permissionsRepository,
        IPermissionsConvertor permissionsConvertor,
        IPermissionsValidator permissionsValidator
    )
        : BaseService<IPermissionsRepository, PermissionsDbo, IPermissionsConvertor, IPermissionsValidator, PermissionsCreateDto, PermissionsListDto, PermissionsDetailDto, PermissionsUpdateDto>(
            permissionsRepository,
            permissionsConvertor,
            permissionsValidator
        ),
            IPermissionsService
    {

    }

}

