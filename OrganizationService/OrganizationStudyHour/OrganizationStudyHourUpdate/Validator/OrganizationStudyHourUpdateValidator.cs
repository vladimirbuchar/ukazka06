using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Validator
{
    public class OrganizationStudyHourUpdateValidator
        : BaseUpdateValidator<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourUpdateDto>,
            IOrganizationStudyHourUpdateValidator
    {
        private readonly ICodeBookRepository<TimeTableDbo> _timeTable;

        public OrganizationStudyHourUpdateValidator(IOrganizationStudyHourRepository repository, ICodeBookRepository<TimeTableDbo> timeTable)
            : base(repository)
        {
            _timeTable = timeTable;
        }

        public override async Task<Result> IsValid(StudyHourUpdateDto update)
        {
            Result validate = new();

            if (await _timeTable.GetEntity(update.ActiveFromId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_FROM, MessageItem.NOT_EXISTS));
            }

            if (await _timeTable.GetEntity(update.ActiveToId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_TO, MessageItem.NOT_EXISTS));
            }

            if (

                    await _repository.GetTotalCount(
                        false,
                        x => x.OrganizationId == update.OrganizationId && x.ActiveFromId == update.ActiveFromId && x.ActiveToId == update.ActiveToId
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
