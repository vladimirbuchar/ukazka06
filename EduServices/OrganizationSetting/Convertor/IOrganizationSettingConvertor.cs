using Core.Base.Convertor;
using Model.Edu.OrganizationSetting;
using Services.OrganizationSetting.Dto;

namespace Services.OrganizationSetting.Convertor
{
    public interface IOrganizationSettingConvertor : IBaseConvertor
    {
        OrganizationSettingDetailDto ConvertToWebModel(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingByUrlDto ConvertToWebModel2(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingDbo ConvertToBussinessEntity(OrganizationSettingUpdateDto saveOrganizationSettingDto, OrganizationSettingDbo setting);

    }
}
