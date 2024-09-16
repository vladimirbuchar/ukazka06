using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Convertor
{
    public class OrganizationStudyHourDetailConvertor : IOrganizationStudyHourDetailConvertor
    {
        public Task<StudyHourDetailDto> ConvertToWebModel(OrganizationStudyHourDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new StudyHourDetailDto
                {
                    ActiveFromId = detail.ActiveFromId,
                    ActiveToId = detail.ActiveToId,
                    Id = detail.Id
                }
            );
        }
    }
}
