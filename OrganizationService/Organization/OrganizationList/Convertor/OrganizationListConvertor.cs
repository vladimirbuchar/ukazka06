using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationList.Dto;

namespace OrganizationService.Organization.OrganizationList.Convertor
{
    public class OrganizationListConvertor : IOrganizationListConvertor
    {
        public Task<List<OrganizationListDto>> ConvertToWebModel(List<OrganizationDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new OrganizationListDto() { Id = item.Id, Name = item.Name }).ToList());
        }
    }
}
