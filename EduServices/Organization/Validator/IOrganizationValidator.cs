using Core.Base.Validator;
using EduRepository.OrganizationRepository;
using EduServices.Organization.Dto;
using Model.Edu.Organization;

namespace EduServices.Organization.Validator
{
    public interface IOrganizationValidator : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        bool ValidateUser { get; set; }
    }
}
