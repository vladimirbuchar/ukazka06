using Core.Base.Service;
using Core.DataTypes;
using Services.OrganizationSetting.Dto;
using System;
using System.Threading.Tasks;

namespace Services.OrganizationSetting.Service
{
    public interface IOrganizationSettingService : IBaseService
    {
        Task<OrganizationSettingDetailDto> GetOrganizationSetting(Guid organizationId);
        Task<OrganizationSettingByUrlDto> GetOrganizationSettingByUrl(string url);
        Task<Result> SaveOrganizationSetting(OrganizationSettingUpdateDto saveOrganizationSettingDto);
    }
}
