using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.System;
using Repository.PermissionsRepository;
using Services.Permissions.Dto;

namespace Services.Permissions.Validator
{
    public class PermissionsValidator(IPermissionsRepository repository)
        : BaseValidator<PermissionsDbo, IPermissionsRepository, PermissionsCreateDto, PermissionsDetailDto, PermissionsUpdateDto>(repository),
            IPermissionsValidator
    {
        public override Result<PermissionsDetailDto> IsValid(PermissionsCreateDto create)
        {
            Result<PermissionsDetailDto> validate = new();
            if (_repository.GetEntity(false, x => x.RouteId == create.RouteId && create.OrganizationRoleId == x.OrganizationRoleId) != null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.PERMISSTIONS, MessageItem.EXISTS));
            }
            return validate;
        }
    }
}
