using Core.Base.Validator;
using Model.System;
using Repository.PermissionsRepository;
using Services.Permissions.Dto;

namespace Services.Permissions.Validator
{
    public interface IPermissionsValidator : IBaseValidator<PermissionsDbo, IPermissionsRepository, PermissionsCreateDto, PermissionsDetailDto, PermissionsUpdateDto> { }
}
