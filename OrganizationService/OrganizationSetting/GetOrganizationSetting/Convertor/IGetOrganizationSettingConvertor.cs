using Core.Base.Convertor;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSetting.Convertor
{
    public interface IGetOrganizationSettingConvertor : IBaseDetailConvertor<OrganizationSettingDbo, OrganizationSettingDetailDto> { }
}
