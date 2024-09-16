using Core.Base.Command.Detail;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto;

namespace OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Command
{
    public interface IGetOrganizationSettingByUrlService : IBaseDetailCommand<OrganizationSettingDbo, OrganizationSettingByUrlDto> { }
}
