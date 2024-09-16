using Core.Base.Command.Delete;
using Model.Edu.Organization;
using Repository.Organization;

namespace OrganizationService.Organization.OrganizationDelete.Command
{
    public class OrganizaionDeleteService : BaseDeleteCommand<OrganizationDbo, IOrganizationRepository>, IOrganizaionDeleteService
    {
        public OrganizaionDeleteService(IOrganizationRepository repository)
            : base(repository) { }
    }
}
