using Core.Base.Validator;
using EduRepository.UserInOrganizationRepository;
using EduServices.UserInOrganization.Dto;
using Model.Link;

namespace EduServices.UserInOrganization.Validator
{
    public class UserInOrganizationValidator(IUserInOrganizationRepository repository)
        : BaseValidator<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationCreateDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>(repository),
            IUserInOrganizationValidator { }
}
