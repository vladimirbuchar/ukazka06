using Core.Base.Validator;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationCreate.Dto;

namespace OrganizationService.Organization.OrganizationCreate.Validator
{
    public interface IOrganizationCreateValidator : IBaseCreateValidator<OrganizationDbo, OrganizationCreateDto>
    {
        bool ValidateUser { get; set; }
    }
}
