using Core.Base.Command.Detail;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSetting.Command
{
    public interface IGetOrganizationSettingService : IBaseDetailCommand<OrganizationSettingDbo, OrganizationSettingDetailDto> { }
}
