using Core.Base.Command.Update;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Validator;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Command
{
    public class OrganizationStudyHourUpdateService
        : BaseUpdateCommand<
            OrganizationStudyHourDbo,
            IOrganizationStudyHourRepository,
            StudyHourUpdateDto,
            IOrganizationStudyHourUpdateConvertor,
            IOrganizationStudyHourUpdateValidator

        >,
            IOrganizationStudyHourUpdateService
    {
        public OrganizationStudyHourUpdateService(
            IOrganizationStudyHourRepository repository,
            IOrganizationStudyHourUpdateConvertor convertor,
            IOrganizationStudyHourUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
