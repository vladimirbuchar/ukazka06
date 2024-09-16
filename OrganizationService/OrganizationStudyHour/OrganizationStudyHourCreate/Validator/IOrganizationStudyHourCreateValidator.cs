using Core.Base.Validator;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Validator
{
    public interface IOrganizationStudyHourCreateValidator : IBaseCreateValidator<OrganizationStudyHourDbo, StudyHourCreateDto> { }
}
