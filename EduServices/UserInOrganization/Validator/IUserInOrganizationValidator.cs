using Core.Base.Validator;
using EduRepository.UserInOrganizationRepository;
using EduServices.UserInOrganization.Dto;
using Model.Tables.Link;

namespace EduServices.UserInOrganization.Validator
{
    public interface IUserInOrganizationValidator
        : IBaseValidator<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationCreateDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto> { }
}
