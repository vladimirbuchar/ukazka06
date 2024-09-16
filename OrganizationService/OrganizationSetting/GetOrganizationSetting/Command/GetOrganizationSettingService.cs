using Core.Base.Command.Detail;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Convertor;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Dto;
using Repository.OrganizationSetting;

namespace OrganizationService.OrganizationSetting.GetOrganizationSetting.Command
{
    public class GetOrganizationSettingService
        : BaseDetailCommand<OrganizationSettingDbo, IOrganizationSettingRepository, OrganizationSettingDetailDto, IGetOrganizationSettingConvertor>,
            IGetOrganizationSettingService
    {
        public GetOrganizationSettingService(IOrganizationSettingRepository repository, IGetOrganizationSettingConvertor convertor)
            : base(repository, convertor) { }
    }
}
