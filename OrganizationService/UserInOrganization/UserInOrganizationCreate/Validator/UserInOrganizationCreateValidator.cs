using Core.Base.Validator;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Dto;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationCreate.Validator
{
    public class UserInOrganizationCreateValidator
        : BaseCreateValidator<UserInOrganizationDbo, IUserInOrganizationRepository, AddUserToOrganization>,
            IUserInOrganizationCreateValidator
    {
        public UserInOrganizationCreateValidator(IUserInOrganizationRepository repository)
            : base(repository) { }
    }
}
