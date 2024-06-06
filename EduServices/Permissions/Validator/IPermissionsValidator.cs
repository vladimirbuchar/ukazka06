using Core.Base.Validator;
using EduRepository.PermissionsRepository;
using EduServices.Permissions.Dto;
using Model.Tables.System;

namespace EduServices.Permissions.Validator
{
    public interface IPermissionsValidator : IBaseValidator<PermissionsDbo, IPermissionsRepository, PermissionsCreateDto, PermissionsDetailDto, PermissionsUpdateDto> { }
}
