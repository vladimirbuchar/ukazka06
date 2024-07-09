using Core.Base.Request;
using Core.Base.Service;
using Model.System;
using Repository.PermissionsRepository;
using Services.Permissions.Convertor;
using Services.Permissions.Dto;
using Services.Permissions.Validator;

namespace Services.Permissions.Service
{
    public class PermissionsService(
        IPermissionsRepository permissionsRepository,
        IPermissionsConvertor permissionsConvertor,
        IPermissionsValidator permissionsValidator
    )
        : BaseService<
            IPermissionsRepository,
            PermissionsDbo,
            IPermissionsConvertor,
            IPermissionsValidator,
            PermissionsCreateDto,
            PermissionsListDto,
            PermissionsDetailDto,
            PermissionsUpdateDto,
            FilterRequest
        >(permissionsRepository, permissionsConvertor, permissionsValidator),
            IPermissionsService { }
}
