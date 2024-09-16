using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Convertor
{
    public class OrganizationStudyHourDropDownConvertor : IOrganizationStudyHourDropDownConvertor
    {
        public Task<List<OrganizationStudyHourDropDownDto>> ConvertToWebModel(List<OrganizationStudyHourDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new OrganizationStudyHourDropDownDto()
            {
                Id = x.Id,
                Name = string.Format("{0} - {1}", x.ActiveFrom.Name, x.ActiveTo.Name),
            }).ToList());
        }
    }
}
