using Core.Base.Command.DropDown;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationDropDown.Service
{
    public interface IUserInOrganizationDropDownService : IBaseDropDownCommand<UserInOrganizationDbo, UserInOrganizationDropDownDto>
    {
    }
}