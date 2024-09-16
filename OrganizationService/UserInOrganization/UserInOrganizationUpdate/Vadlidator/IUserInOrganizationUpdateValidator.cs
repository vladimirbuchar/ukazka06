using Core.Base.Validator;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationUpdate.Vadlidator
{
    public interface IUserInOrganizationUpdateValidator : IBaseUpdateValidator<UserInOrganizationDbo, UserInOrganizationUpdateDto> { }
}
