using Core.Base.Command.Update;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Command
{
    public interface IOrganizationStudyHourUpdateService : IBaseUpdateCommand<OrganizationStudyHourDbo, StudyHourUpdateDto> { }
}
