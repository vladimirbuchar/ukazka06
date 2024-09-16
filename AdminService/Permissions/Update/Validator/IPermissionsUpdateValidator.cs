using AdminService.Permissions.Update.Dto;
using Core.Base.Validator;
using Model.System;

namespace AdminService.Permissions.Update.Validator
{
    public interface IPermissionsUpdateValidator : IBaseUpdateValidator<PermissionsDbo, PermissionsUpdateDto> { }
}
