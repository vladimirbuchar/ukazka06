using Core.Base.Command.Update;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationUpdate.Command
{
    public interface IUserInOrganizationUpdateService : IBaseUpdateCommand<UserInOrganizationDbo, UserInOrganizationUpdateDto> { }
}
