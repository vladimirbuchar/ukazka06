using Core.Base.Command.Create;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Command
{
    public interface IOrganizationStudyHourCreateService : IBaseCreateCommand<OrganizationStudyHourDbo, StudyHourCreateDto> { }
}
