using Core.Base.Validator;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Validator
{
    public interface IOrganizationCultureCreateValidator : IBaseCreateValidator<OrganizationCultureDbo, OrganizationCultureCreateDto> { }
}
