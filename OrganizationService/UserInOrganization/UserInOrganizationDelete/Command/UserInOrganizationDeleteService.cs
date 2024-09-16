using Core.Base.Command.MultipleDelete;
using Model.Link;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationDelete.Command
{
    public class UserInOrganizationDeleteService
        : BaseMultipleDeleteCommand<UserInOrganizationDbo, IUserInOrganizationRepository>,
            IUserInOrganizationDeleteService
    {
        public UserInOrganizationDeleteService(IUserInOrganizationRepository repository)
            : base(repository) { }
    }
}
