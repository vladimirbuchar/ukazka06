using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Convertor
{
    public class OrganizationCultureUpdateConvertor : IOrganizationCultureUpdateConvertor
    {
        public Task<OrganizationCultureDbo> ConvertToBussinessEntity(
            OrganizationCultureUpdateDto update,
            OrganizationCultureDbo entity,
            string culture
        )
        {
            entity.IsDefault = update.IsDefault;
            return Task.FromResult(entity);
        }
    }
}
