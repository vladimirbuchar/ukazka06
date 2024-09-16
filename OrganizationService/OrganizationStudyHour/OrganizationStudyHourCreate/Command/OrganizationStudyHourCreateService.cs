using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Validator;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Command
{
    public class OrganizationStudyHourCreateService
        : BaseCreateCommand<
            OrganizationStudyHourDbo,
            IOrganizationStudyHourRepository,
            StudyHourCreateDto,
            IOrganizationStudyHourCreateConvertor,
            IOrganizationStudyHourCreateValidator
        >,
            IOrganizationStudyHourCreateService
    {
        private readonly ICodeBookRepository<TimeTableDbo> _timeTables;

        public OrganizationStudyHourCreateService(
            ICodeBookRepository<TimeTableDbo> timeTables,
            IOrganizationStudyHourRepository repository,
            IOrganizationStudyHourCreateConvertor convertor,
            IOrganizationStudyHourCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _timeTables = timeTables;
        }

        public override async Task<ResultInsert> Execute(StudyHourCreateDto addObject, Guid userId, string culture)
        {
            //OrganizationStudyHourDbo addStudyHours = await _convertor.ConvertToBussinessEntity(addObject, culture);
            if (addObject.ActiveFromId != Guid.Empty && addObject.ActiveToId == Guid.Empty && addObject.LessonLength > 0)
            {
                TimeTableDbo timeTable = await _timeTables.GetEntity(false, x => x.Id == addObject.ActiveFromId);
                if (timeTable != null)
                {
                    addObject.ActiveToId = (
                        await _timeTables.GetEntity(false, x => x.Priority == timeTable.Priority + addObject.LessonLength / 5)
                    ).Id;
                }
            }
            return await base.Execute(addObject, userId, culture);
        }
    }
}
