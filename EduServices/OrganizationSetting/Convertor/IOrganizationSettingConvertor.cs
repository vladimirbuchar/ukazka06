using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.OrganizationCulture.Dto;
using EduServices.OrganizationSetting.Dto;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Link;

namespace EduServices.OrganizationSetting.Convertor
{
    public interface IOrganizationSettingConvertor : IBaseConvertor
    {
        OrganizationSettingDetailDto ConvertToWebModel(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingByUrlDto ConvertToWebModel2(OrganizationSettingDbo getOrganizationSetting);
        OrganizationSettingDbo ConvertToBussinessEntity(OrganizationSettingUpdateDto saveOrganizationSettingDto, OrganizationSettingDbo setting);
        HashSet<OrganizationCultureListDto> ConvertToWebModel(HashSet<OrganizationCultureDbo> getOrganizationCultures);
    }
}
