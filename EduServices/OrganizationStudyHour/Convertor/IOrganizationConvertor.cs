using Core.Base.Convertor;
using Model.Edu.OrganizationStudyHour;
using Services.OrganizationStudyHour.Dto;

namespace Services.OrganizationStudyHour.Convertor
{
    public interface IOrganizationStudyHourConvertor : IBaseConvertor<OrganizationStudyHourDbo, StudyHourCreateDto, StudyHourListDto, StudyHourDetailDto, StudyHourUpdateDto> { }
}
