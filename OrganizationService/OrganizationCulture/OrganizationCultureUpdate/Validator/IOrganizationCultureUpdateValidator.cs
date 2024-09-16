using Core.Base.Validator;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Validator
{
    public interface IOrganizationCultureUpdateValidator : IBaseUpdateValidator<OrganizationCultureDbo, OrganizationCultureUpdateDto> { }
}
