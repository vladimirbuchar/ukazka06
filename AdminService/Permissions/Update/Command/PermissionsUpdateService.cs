using AdminService.Permissions.Update.Convertor;
using AdminService.Permissions.Update.Dto;
using AdminService.Permissions.Update.Validator;
using Core.Base.Command.Update;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Update.Command
{
    public class PermissionsUpdateService(
        IPermissionsRepository repository,
        IPermissionsUpdateConvertor convertor,
        IPermissionsUpdateValidator validator
    )
        : BaseUpdateCommand<PermissionsDbo, IPermissionsRepository, PermissionsUpdateDto, IPermissionsUpdateConvertor, IPermissionsUpdateValidator>(
            repository,
            convertor,
            validator
        ),
            IPermissionsUpdateService
    { }
}
