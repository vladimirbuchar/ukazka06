using Core.Base.Command.Detail;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Dto;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Command
{
    public class OrganizationStudyHourDetailService
        : BaseDetailCommand<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourDetailDto, IOrganizationStudyHourDetailConvertor>,
            IOrganizationStudyHourDetailService
    {
        public OrganizationStudyHourDetailService(IOrganizationStudyHourRepository repository, IOrganizationStudyHourDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
