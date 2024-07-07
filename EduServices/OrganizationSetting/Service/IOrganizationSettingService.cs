using Core.Base.Service;
using Core.DataTypes;
using Services.OrganizationSetting.Dto;
using System;

namespace Services.OrganizationSetting.Service
{
    public interface IOrganizationSettingService : IBaseService
    {
        OrganizationSettingDetailDto GetOrganizationSetting(Guid organizationId);
        OrganizationSettingByUrlDto GetOrganizationSettingByUrl(string url);
        Result SaveOrganizationSetting(OrganizationSettingUpdateDto saveOrganizationSettingDto);
    }
}
