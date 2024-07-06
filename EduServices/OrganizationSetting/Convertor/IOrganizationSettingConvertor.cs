using Core.Base.Convertor;
using EduServices.OrganizationSetting.Dto;
using Model.Edu.OrganizationSetting;

namespace EduServices.OrganizationSetting.Convertor
{
    public interface IOrganizationSettingConvertor : IBaseConvertor
    {
        OrganizationSettingDetailDto ConvertToWebModel(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingByUrlDto ConvertToWebModel2(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingDbo ConvertToBussinessEntity(OrganizationSettingUpdateDto saveOrganizationSettingDto, OrganizationSettingDbo setting);

    }
}
