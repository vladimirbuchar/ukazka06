using Core.Base.Validator;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Validator
{
    public interface IOrganizationSettingUpdateValidator : IBaseUpdateValidator<OrganizationSettingDbo, OrganizationSettingUpdateDto> { }
}
