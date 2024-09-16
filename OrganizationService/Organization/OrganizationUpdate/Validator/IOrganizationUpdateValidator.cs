using Core.Base.Validator;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationUpdate.Dto;

namespace OrganizationService.Organization.OrganizationUpdate.Validator
{
    public interface IOrganizationUpdateValidator : IBaseUpdateValidator<OrganizationDbo, OrganizationUpdateDto> { }
}
