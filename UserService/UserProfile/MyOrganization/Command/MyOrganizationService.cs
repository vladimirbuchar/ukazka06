using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Link;
using Repository.UserInOrganization;
using UserService.UserProfile.MyOrganization.Convertor;
using UserService.UserProfile.MyOrganization.Dto;

namespace UserService.UserProfile.MyOrganization.Command
{
    public class MyOrganizationService
        : BaseListCommand<UserInOrganizationDbo, IUserInOrganizationRepository, MyOrganizationListDto, IMyOrganizationConvertor, RequestFilter>,
            IMyOrganizationService
    {
        public MyOrganizationService(IUserInOrganizationRepository repository, IMyOrganizationConvertor convertor)
            : base(repository, convertor) { }
    }
}
