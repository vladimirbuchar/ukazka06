using Core.Base.Command.Detail;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Command
{
    public interface IOrganizationStudyHourDetailService : IBaseDetailCommand<OrganizationStudyHourDbo, StudyHourDetailDto> { }
}
