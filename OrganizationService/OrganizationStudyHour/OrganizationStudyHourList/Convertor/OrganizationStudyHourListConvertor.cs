using Model.Edu.OrganizationStudyHour;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Convertor
{
    public class OrganizationStudyHourListConvertor : IOrganizationStudyHourListConvertor
    {
        public Task<List<StudyHourListDto>> ConvertToWebModel(List<OrganizationStudyHourDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new StudyHourListDto()
                {
                    Position = x.Position,
                    ActiveFrom = x.ActiveFrom.Value,
                    ActiveFromId = x.ActiveFromId,
                    ActiveTo = x.ActiveTo.Value,
                    ActiveToId = x.ActiveToId,
                    Id = x.Id
                })
                    .ToList()
            );
        }
    }
}
