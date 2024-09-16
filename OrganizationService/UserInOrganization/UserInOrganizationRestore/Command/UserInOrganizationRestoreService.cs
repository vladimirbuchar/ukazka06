using Core.Base.Command.Restore;
using Model.Link;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationRestore.Command
{
    public class UserInOrganizationRestoreService
        : BaseRestoreCommand<UserInOrganizationDbo, IUserInOrganizationRepository>,
            IUserInOrganizationRestoreService
    {
        public UserInOrganizationRestoreService(IUserInOrganizationRepository repository)
            : base(repository) { }
    }
}
