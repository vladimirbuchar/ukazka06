using AdminService.Permissions.Create.Dto;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Create.Validator
{
    public class PermissionsCreateValidator(IPermissionsRepository repository)
        : BaseCreateValidator<PermissionsDbo, IPermissionsRepository, PermissionsCreateDto>(repository),
            IPermissionsCreateValidator
    {
        public override async Task<ResultInsert> IsValid(PermissionsCreateDto create)
        {
            ResultInsert validate = new();
            if (await _repository.GetEntity(false, x => x.RouteId == create.RouteId && create.OrganizationRoleId == x.OrganizationRoleId) != null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.PERMISSTIONS, MessageItem.EXISTS));
            }
            return await Task.FromResult(validate);
        }
    }
}
