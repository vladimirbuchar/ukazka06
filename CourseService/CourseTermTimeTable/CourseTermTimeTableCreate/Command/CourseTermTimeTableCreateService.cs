using Core.Base.Command.Create;
using Core.DataTypes;
using CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Dto;
using Model.Edu.CourseTermDate;
using Repository.CourseTerm;
using Repository.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Command
{
    public class CourseTermTimeTableCreateService
        : BaseCreateCommand<CourseTermDateDbo, ICourseTermDateRepository, CourseTermTimeTableCreateDto>,
            ICourseTermTimeTableCreateService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermTimeTableCreateService(ICourseTermRepository courseTermRepository, ICourseTermDateRepository repository)
            : base(repository)
        {
            _courseTermRepository = courseTermRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseTermRepository.GetOrganizationId(objectId);
        }

        public override async Task<ResultInsert> Execute(CourseTermTimeTableCreateDto addObject, Guid userId, string culture)
        {
            DateTime activeFromDate = addObject.ActiveFrom.Value;
            DateTime activeToDate = addObject.ActiveTo.Value;
            bool monday = addObject.Days[0];
            bool tuesday = addObject.Days[1];
            bool wednesday = addObject.Days[2];
            bool thursday = addObject.Days[3];
            bool friday = addObject.Days[4];
            bool saturday = addObject.Days[5];
            bool sunday = addObject.Days[6];
            DateTime nextDay = activeFromDate;

            while (nextDay <= activeToDate)
            {
                foreach (Guid lector in addObject.LectorIds)
                {
                    if (monday && nextDay.DayOfWeek == DayOfWeek.Monday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_MONDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false,
                            },
                            userId
                        );
                    }
                    if (tuesday && nextDay.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_TUESDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                    if (wednesday && nextDay.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_WEDNESDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                    if (thursday && nextDay.DayOfWeek == DayOfWeek.Thursday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_THURSDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                    if (friday && nextDay.DayOfWeek == DayOfWeek.Friday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_FRIDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                    if (saturday && nextDay.DayOfWeek == DayOfWeek.Saturday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_SATURDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                    if (sunday && nextDay.DayOfWeek == DayOfWeek.Sunday)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_SUNDAY",
                                TimeFromId = addObject.TimeFromId,
                                TimeToId = addObject.TimeToId,
                                UserInOrganizationId = lector,
                                ClassRoomId = addObject.ClassRoomId,
                                IsCanceled = false
                            },
                            userId
                        );
                    }
                }
                nextDay = nextDay.AddDays(1);
            }
            return new ResultInsert();
        }
    }
}
