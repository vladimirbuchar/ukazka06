using AdminService.Permissions.Create.Dto;
using Core.Base.Validator;
using Model.System;

namespace AdminService.Permissions.Create.Validator
{
    public interface IPermissionsCreateValidator : IBaseCreateValidator<PermissionsDbo, PermissionsCreateDto> { }
}
