using Core.Base.Service;
using Model.Edu.OrganizationStudyHour;
using Services.OrganizationStudyHour.Dto;

namespace Services.OrganizationStudyHour.Service
{
    public interface IOrganizationStudyHourService : IBaseService<OrganizationStudyHourDbo, StudyHourCreateDto, StudyHourListDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
