using AdminService.Permissions.Update.Dto;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Update.Validator
{
    public class PermissionsUpdateValidator(IPermissionsRepository repository)
        : BaseUpdateValidator<PermissionsDbo, IPermissionsRepository, PermissionsUpdateDto>(repository),
            IPermissionsUpdateValidator
    {
        public override async Task<Result> IsValid(PermissionsUpdateDto update)
        {
            Result validate = new();
            if (await _repository.GetEntity(false, x => x.RouteId == update.RouteId && update.OrganizationRoleId == x.OrganizationRoleId) != null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.PERMISSTIONS, MessageItem.EXISTS));
            }
            return await Task.FromResult(validate);
        }
    }
}
