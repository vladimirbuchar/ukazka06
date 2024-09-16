using Core.Base.Convertor;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Convertor
{
    public interface IOrganizationSettingUpdateConvertor : IBaseUpdateConvertor<OrganizationSettingDbo, OrganizationSettingUpdateDto> { }
}
