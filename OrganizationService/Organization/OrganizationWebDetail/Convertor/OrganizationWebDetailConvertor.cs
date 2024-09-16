using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationWebDetail.Dto;

namespace OrganizationService.Organization.OrganizationWebDetail.Convertor
{
    public class OrganizationWebDetailConvertor : IOrganizationWebDetailConvertor
    {
        public Task<OrganizationDetailWebDto> ConvertToWebModel(OrganizationDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new OrganizationDetailWebDto()
                {
                    Id = detail.Id,
                    Description = detail.OrganizationTranslations.FindTranslation(culture)?.Description,
                    Name = detail.Name,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    WWW = detail.WWW
                }
            );
        }
    }
}
