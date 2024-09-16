using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;
using Repository.Organization;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Validator
{
    public class OrganizationStudyHourCreateValidator(
        ICodeBookRepository<TimeTableDbo> timeTable,
        IOrganizationStudyHourRepository repository,
        IOrganizationRepository organizationRepository
        )
                : BaseCreateValidator<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourCreateDto>(repository),
            IOrganizationStudyHourCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly ICodeBookRepository<TimeTableDbo> _timeTable = timeTable;

        public override async Task<ResultInsert> IsValid(StudyHourCreateDto create)
        {
            ResultInsert validate = new();

            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            if (await _timeTable.GetEntity(create.ActiveFromId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_FROM, MessageItem.NOT_EXISTS));
            }

            if (create.ActiveToId.HasValue && await _timeTable.GetEntity(create.ActiveToId.Value) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_TO, MessageItem.NOT_EXISTS));
            }
            if (

                    await _repository.GetTotalCount(
                        false,
                        x => x.OrganizationId == create.OrganizationId && x.ActiveFromId == create.ActiveFromId && x.ActiveToId == create.ActiveToId
                    )
                 > 0
            )
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_FROM, MessageItem.EXISTS));
            }
            return validate;
        }
    }
}
