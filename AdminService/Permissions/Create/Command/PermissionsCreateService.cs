using AdminService.Permissions.Create.Convertor;
using AdminService.Permissions.Create.Dto;
using AdminService.Permissions.Create.Validator;
using Core.Base.Command.Create;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Create.Command
{
    public class PermissionsCreateService(
        IPermissionsRepository repository,
        IPermissionsCreateConvertor convertor,
        IPermissionsCreateValidator validator
    )
        : BaseCreateCommand<PermissionsDbo, IPermissionsRepository, PermissionsCreateDto, IPermissionsCreateConvertor, IPermissionsCreateValidator>(
            repository,
            convertor,
            validator
        ),
            IPermissionsCreateService
    { }
}
