using Core.Base.Validator;
using Model.Edu.OrganizationStudyHour;
using Repository.OrganizationHoursRepository;
using Services.OrganizationStudyHour.Dto;

namespace Services.OrganizationStudyHour.Validator
{
    public interface IOrganizationStudyHourValidator
        : IBaseValidator<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourCreateDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
