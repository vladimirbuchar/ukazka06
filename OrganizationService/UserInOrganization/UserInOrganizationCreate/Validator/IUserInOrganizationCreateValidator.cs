using Core.Base.Validator;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationCreate.Validator
{
    public interface IUserInOrganizationCreateValidator : IBaseCreateValidator<UserInOrganizationDbo, AddUserToOrganization> { }
}
