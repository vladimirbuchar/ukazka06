using Core.Base.Service;
using EduServices.OrganizationStudyHour.Dto;
using Model.Tables.Edu.OrganizationStudyHour;

namespace EduServices.OrganizationStudyHour.Service
{
    public interface IOrganizationStudyHourService : IBaseService<OrganizationStudyHourDbo, StudyHourCreateDto, StudyHourListDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
