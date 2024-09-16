using Core.Base.Convertor;
using Model.Edu.OrganizationStudyHour;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Convertor
{
    public interface IOrganizationStudyHourListConvertor : IBaseListConvertor<OrganizationStudyHourDbo, StudyHourListDto> { }
}
