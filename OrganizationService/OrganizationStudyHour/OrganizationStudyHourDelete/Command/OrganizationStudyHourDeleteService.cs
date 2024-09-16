using Core.Base.Command.Delete;
using Model.Edu.OrganizationStudyHour;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDelete.Command
{
    public class OrganizationStudyHourDeleteService
        : BaseDeleteCommand<OrganizationStudyHourDbo, IOrganizationStudyHourRepository>,
            IOrganizationStudyHourDeleteService
    {
        public OrganizationStudyHourDeleteService(IOrganizationStudyHourRepository repository)
            : base(repository) { }
    }
}
