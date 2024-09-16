using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Link;
using UserService.UserProfile.MyOrganization.Dto;

namespace UserService.UserProfile.MyOrganization.Command
{
    public interface IMyOrganizationService : IBaseListCommand<UserInOrganizationDbo, MyOrganizationListDto, RequestFilter> { }
}
