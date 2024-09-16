using Core.Base.Validator;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Dto;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationUpdate.Vadlidator
{
    public class UserInOrganizationUpdateValidator
        : BaseUpdateValidator<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationUpdateDto>,
            IUserInOrganizationUpdateValidator
    {
        public UserInOrganizationUpdateValidator(IUserInOrganizationRepository repository)
            : base(repository) { }
    }
}
