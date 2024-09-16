using Core.Base.Command;
using Core.Constants;
using Model.Edu.Course;
using Model.Edu.CourseTermDate;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.ClassRoom.ClassRoomTimeTable.Dto;
using Repository.ClassRoom;
using Repository.OrganizationHoursRepository;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.ClassRoom.ClassRoomTimeTable.Command
{
    public class ClassRoomTimeTableService : BaseCommand, IClassRoomTimeTableService
    {
        private readonly IClassRoomRepository _repository;

        private readonly IOrganizationStudyHourRepository _organizationStudyHourRepository;

        public ClassRoomTimeTableService(IClassRoomRepository repository, IOrganizationStudyHourRepository organizationStudyHourRepository)
        {
            _repository = repository;
            _organizationStudyHourRepository = organizationStudyHourRepository;
        }

        public virtual async Task<ClassRoomTimeTableDto> Execute(Guid classRoomId, Guid organizationId, List<string> culture)
        {
            ClassRoomTimeTableDto getClassRoomTimeTableDtos = new();
            List<CourseTermDateDbo> getClassRoomTimeTables = (await _repository.GetEntity(false, x => x.Id == classRoomId)).CourseTermDates.ToList();
            List<OrganizationStudyHourDbo> getStudyHours = await _organizationStudyHourRepository.GetEntities(
                false,
                x => x.OrganizationId == organizationId,
                null,
                [new Core.Base.Sort.BaseSort<OrganizationStudyHourDbo>() { Sort = x => x.Position }]
            );

            getClassRoomTimeTableDtos.StudyHours = getStudyHours
                .Select(x => new StudyHourListDto()
                {
                    ActiveFrom = x.ActiveFrom.Value,
                    ActiveFromId = x.ActiveFromId,
                    ActiveTo = x.ActiveTo.Value,
                    ActiveToId = x.ActiveToId,
                    Id = x.Id,
                    Position = x.Position
                })
                .ToList();
            List<CourseTermDateDbo> monday = getClassRoomTimeTables.Where(x => x.CourseTerm.Monday).ToList();
            List<CourseTermDateDbo> tuesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Tuesday).ToList();
            List<CourseTermDateDbo> wednesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Wednesday).ToList();
            List<CourseTermDateDbo> thursday = getClassRoomTimeTables.Where(x => x.CourseTerm.Thursday).ToList();
            List<CourseTermDateDbo> friday = getClassRoomTimeTables.Where(x => x.CourseTerm.Friday).ToList();
            List<CourseTermDateDbo> saturday = getClassRoomTimeTables.Where(x => x.CourseTerm.Saturday).ToList();
            List<CourseTermDateDbo> sunday = getClassRoomTimeTables.Where(x => x.CourseTerm.Sunday).ToList();
            PrepareTimeTable(monday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_MONDAY, culture);
            PrepareTimeTable(tuesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_TUESDAY, culture);
            PrepareTimeTable(wednesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_WEDNESDAY, culture);
            PrepareTimeTable(thursday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_THURSDAY, culture);
            PrepareTimeTable(friday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_FRIDAY, culture);
            PrepareTimeTable(saturday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SATURDAY, culture);
            PrepareTimeTable(sunday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SUNDAY, culture);
            return getClassRoomTimeTableDtos;
        }

        private static void PrepareTimeTable(
            List<CourseTermDateDbo> day,
            List<OrganizationStudyHourDbo> getStudyHours,
            ClassRoomTimeTableDto timeTableItem,
            string dayName,
            List<string> culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string? courseName = "";
                courseName = day.FirstOrDefault(x => x.TimeFromId == item.ActiveFromId && x.TimeToId == item.ActiveToId)
                    ?.CourseTerm.Course.CourseTranslations.FindTranslation(culture)
                    .Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }

        public async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
