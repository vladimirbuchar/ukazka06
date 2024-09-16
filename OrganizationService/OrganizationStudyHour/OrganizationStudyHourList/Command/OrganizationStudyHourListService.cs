using Core.Base.Command.List;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Filter;
using Repository.OrganizationHoursRepository;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Command
{
    public class OrganizationStudyHourListService
        : BaseListCommand<
            OrganizationStudyHourDbo,
            IOrganizationStudyHourRepository,
            StudyHourListDto,
            IOrganizationStudyHourListConvertor,
            OrganizationStudyHourFilter
        >,
            IOrganizationStudyHourListService
    {
        public OrganizationStudyHourListService(IOrganizationStudyHourRepository repository, IOrganizationStudyHourListConvertor convertor)
            : base(repository, convertor) { }
    }
}
