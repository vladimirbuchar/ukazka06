using Core.Base.Command.Detail;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationDetail.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationDetail.Command
{
    public interface IUserInOrganizationDetailService : IBaseDetailCommand<UserInOrganizationDbo, UserInOrganizationDetailDto> { }
}
