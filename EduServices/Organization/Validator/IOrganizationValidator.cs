using Core.Base.Validator;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Services.Organization.Dto;

namespace Services.Organization.Validator
{
    public interface IOrganizationValidator
        : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        bool ValidateUser { get; set; }
    }
}
