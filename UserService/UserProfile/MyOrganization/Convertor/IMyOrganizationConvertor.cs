using Core.Base.Convertor;
using Model.Link;
using UserService.UserProfile.MyOrganization.Dto;

namespace UserService.UserProfile.MyOrganization.Convertor
{
    public interface IMyOrganizationConvertor : IBaseListConvertor<UserInOrganizationDbo, MyOrganizationListDto> { }
}
