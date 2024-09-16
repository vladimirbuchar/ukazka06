using Core.Base.Command.List;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Filter;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Command
{
    public interface IOrganizationStudyHourListService : IBaseListCommand<OrganizationStudyHourDbo, StudyHourListDto, OrganizationStudyHourFilter> { }
}
