using Core.Base.Validator;
using EduRepository.OrganizationHoursRepository;
using EduServices.OrganizationStudyHour.Dto;
using Model.Tables.Edu.OrganizationStudyHour;

namespace EduServices.OrganizationStudyHour.Validator
{
    public interface IOrganizationStudyHourValidator : IBaseValidator<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourCreateDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
