using Core.Base.Command.Detail;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Convertor;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto;
using Repository.OrganizationSetting;

namespace OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Command
{
    public class GetOrganizationSettingByUrlService
        : BaseDetailCommand<
            OrganizationSettingDbo,
            IOrganizationSettingRepository,
            OrganizationSettingByUrlDto,
            IGetOrganizationSettingByUrlConvertor
        >,
            IGetOrganizationSettingByUrlService
    {
        public GetOrganizationSettingByUrlService(IOrganizationSettingRepository repository, IGetOrganizationSettingByUrlConvertor convertor)
            : base(repository, convertor) { }
    }
}
