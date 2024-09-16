using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureList.Convertor
{
    public class OrganizationCultureListConvertor : IOrganizationCultureListConvertor
    {
        public Task<List<OrganizationCultureListDto>> ConvertToWebModel(List<OrganizationCultureDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new OrganizationCultureListDto()
                {
                    Id = item.Id,
                    IsDefault = item.IsDefault,
                    Name = item.Culture.Name,
                    CultureId = item.CultureId
                })
                    .ToList()
            );
        }
    }
}
