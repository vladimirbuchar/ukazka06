using Core.Base.Command.Restore;
using Model.Link;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureRestore.Command
{
    public class OrganizationCultureRestoreService
        : BaseRestoreCommand<OrganizationCultureDbo, IOrganizationCultureRepository>,
            IOrganizationCultureRestoreService
    {
        public OrganizationCultureRestoreService(IOrganizationCultureRepository repository)
            : base(repository) { }
    }
}
