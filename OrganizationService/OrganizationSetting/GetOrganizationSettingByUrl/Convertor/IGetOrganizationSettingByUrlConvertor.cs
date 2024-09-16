using Core.Base.Convertor;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Convertor
{
    public interface IGetOrganizationSettingByUrlConvertor : IBaseDetailConvertor<OrganizationSettingDbo, OrganizationSettingByUrlDto> { }
}
