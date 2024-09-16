using Core.Base.Validator;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Validator
{
    public interface IOrganizationStudyHourUpdateValidator : IBaseUpdateValidator<OrganizationStudyHourDbo, StudyHourUpdateDto> { }
}
