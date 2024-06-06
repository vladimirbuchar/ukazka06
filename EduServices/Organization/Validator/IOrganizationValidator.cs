using Core.Base.Validator;
using EduRepository.OrganizationRepository;
using EduServices.Organization.Dto;
using Model.Tables.Edu.Organization;

namespace EduServices.Organization.Validator
{
    public interface IOrganizationValidator : IBaseValidator<OrganizationDbo, IOrganizationRepository, OrganizationCreateDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        bool ValidateUser { get; set; }
    }
}
