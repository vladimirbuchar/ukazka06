using Core.Base.Service;
using Core.DataTypes;
using EduServices.OrganizationSetting.Dto;
using System;

namespace EduServices.OrganizationSetting.Service
{
    public interface IOrganizationSettingService : IBaseService
    {
        OrganizationSettingDetailDto GetOrganizationSetting(Guid organizationId);
        OrganizationSettingByUrlDto GetOrganizationSettingByUrl(string url);
        Result SaveOrganizationSetting(OrganizationSettingUpdateDto saveOrganizationSettingDto);
    }
}
