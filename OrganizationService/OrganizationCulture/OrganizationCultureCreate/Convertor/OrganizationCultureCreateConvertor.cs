using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Convertor
{
    public class OrganizationCultureCreateConvertor : IOrganizationCultureCreateConvertor
    {
        public Task<OrganizationCultureDbo> ConvertToBussinessEntity(OrganizationCultureCreateDto create, string culture)
        {
            return Task.FromResult(
                new OrganizationCultureDbo()
                {
                    OrganizationId = create.OrganizationId,
                    CultureId = create.CultureId,
                    IsDefault = create.IsDefault
                }
            );
        }
    }
}
