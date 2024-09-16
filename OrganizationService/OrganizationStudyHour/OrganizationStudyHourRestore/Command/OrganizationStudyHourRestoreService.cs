using Core.Base.Command.Restore;
using Model.Edu.OrganizationStudyHour;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourRestore.Command
{
    public class OrganizationStudyHourRestoreService
        : BaseRestoreCommand<OrganizationStudyHourDbo, IOrganizationStudyHourRepository>,
            IOrganizationStudyHourRestoreService
    {
        public OrganizationStudyHourRestoreService(IOrganizationStudyHourRepository repository)
            : base(repository) { }
    }
}
