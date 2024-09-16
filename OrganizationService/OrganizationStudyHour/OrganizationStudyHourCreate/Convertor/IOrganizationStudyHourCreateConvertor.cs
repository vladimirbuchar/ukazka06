using Core.Base.Convertor;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Convertor
{
    public interface IOrganizationStudyHourCreateConvertor : IBaseCreateConvertor<OrganizationStudyHourDbo, StudyHourCreateDto> { }
}
