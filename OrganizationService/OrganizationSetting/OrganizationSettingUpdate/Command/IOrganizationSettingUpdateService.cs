using Core.Base.Command.Update;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Command
{
    public interface IOrganizationSettingUpdateService : IBaseUpdateCommand<OrganizationSettingDbo, OrganizationSettingUpdateDto> { }
}
