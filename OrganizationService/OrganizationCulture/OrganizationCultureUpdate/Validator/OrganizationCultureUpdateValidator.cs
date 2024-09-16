using Core.Base.Validator;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Validator
{
    public class OrganizationCultureUpdateValidator
        : BaseUpdateValidator<OrganizationCultureDbo, IOrganizationCultureRepository, OrganizationCultureUpdateDto>,
            IOrganizationCultureUpdateValidator
    {
        public OrganizationCultureUpdateValidator(IOrganizationCultureRepository repository)
            : base(repository) { }
    }
}
