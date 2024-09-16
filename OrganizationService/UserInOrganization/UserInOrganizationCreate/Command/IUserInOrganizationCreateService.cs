using Core.Base.Command.Create;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationCreate.Command
{
    public interface IUserInOrganizationCreateService : IBaseCreateCommand<UserInOrganizationDbo, AddUserToOrganization> { }
}
