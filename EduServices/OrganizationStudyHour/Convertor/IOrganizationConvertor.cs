using Core.Base.Convertor;
using EduServices.OrganizationStudyHour.Dto;
using Model.Edu.OrganizationStudyHour;

namespace EduServices.OrganizationStudyHour.Convertor
{
    public interface IOrganizationStudyHourConvertor : IBaseConvertor<OrganizationStudyHourDbo, StudyHourCreateDto, StudyHourListDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
