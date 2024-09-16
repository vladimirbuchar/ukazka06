using Core.Base.Command.List;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationList.Dto;
using OrganizationService.UserInOrganization.UserInOrganizationList.Filter;

namespace OrganizationService.UserInOrganization.UserInOrganizationList.Command
{
    public interface IUserInOrganizationListService : IBaseListCommand<UserInOrganizationDbo, UserInOrganizationListDto, UserInOrganizationFilter> { }
}
