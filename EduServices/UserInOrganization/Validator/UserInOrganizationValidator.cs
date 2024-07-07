using Core.Base.Validator;
using Model.Link;
using Repository.UserInOrganizationRepository;
using Services.UserInOrganization.Dto;

namespace Services.UserInOrganization.Validator
{
    public class UserInOrganizationValidator(IUserInOrganizationRepository repository)
        : BaseValidator<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationCreateDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto>(repository),
            IUserInOrganizationValidator { }
}
