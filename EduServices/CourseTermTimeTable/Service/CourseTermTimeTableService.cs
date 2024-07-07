using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseTerm;
using Model.Edu.CourseTermDate;
using Repository.CourseLectorRepository;
using Repository.CourseTermDateRepository;
using Repository.CourseTermRepository;
using Services.CourseTermTimeTable.Convertor;
using Services.CourseTermTimeTable.Dto;

namespace Services.CourseTermTimeTable.Service
{
    public class CourseTermTimeTableService(
        ICourseTermDateRepository courseTermDateRepository,
        ICourseLectorRepository courseLectorRepository,
        ICourseTermRepository courseTermRepository,
        ICourseTermTimeTableConvertor convertor
    ) : BaseService<ICourseTermDateRepository, CourseTermDateDbo, ICourseTermTimeTableConvertor>(courseTermDateRepository, convertor), ICourseTermTimeTableService
    {
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public Result GenerateTimeTable(Guid courseTermId)
        {
            CourseTermDbo getCourseTermDetail = _courseTermRepository.GetEntity(courseTermId);
            HashSet<CourseTermDateDbo> getTimeTables = _repository.GetEntities(false, x => x.CourseTermId == courseTermId && x.Date >= DateTime.Now);
            foreach (CourseTermDateDbo item in getTimeTables)
            {
                _repository.DeleteEntity(item.Id, Guid.Empty);
            }
            DateTime activeFrom = getCourseTermDetail.ActiveFrom.Value.Date;
            if (activeFrom < DateTime.Now.Date)
            {
                activeFrom = DateTime.Now.Date;
            }

            _ = GenerateTimeTable(
                activeFrom,
                getCourseTermDetail.ActiveTo.Value.Date,
                getCourseTermDetail.TimeFromId,
                getCourseTermDetail.TimeToId,
                [
                    getCourseTermDetail.Monday,
                    getCourseTermDetail.Tuesday,
                    getCourseTermDetail.Wednesday,
                    getCourseTermDetail.Thursday,
                    getCourseTermDetail.Friday,
                    getCourseTermDetail.Saturday,
                    getCourseTermDetail.Sunday
                ],
                courseTermId,
                _courseLectorRepository.GetEntities(false, x => x.CourseTermId == courseTermId).Select(x => x.UserInOrganizationId.ToString()).ToList(),
                getCourseTermDetail.ClassRoomId
            );
            return new Result();
        }

        public Result GenerateTimeTable(DateTime activeFrom, DateTime activeTo, Guid timeFromId, Guid timeToId, List<bool> days, Guid courseTermId, List<string> lectors, Guid classRoomId)
        {
            DateTime activeFromDate = activeFrom.Date;
            DateTime activeToDate = activeTo.Date;
            bool monday = days[0];
            bool tuesday = days[1];
            bool wednesday = days[2];
            bool thursday = days[3];
            bool friday = days[4];
            bool saturday = days[5];
            bool sunday = days[6];
            DateTime nextDay = activeFromDate;

            while (nextDay <= activeToDate)
            {
                foreach (string lector in lectors)
                {
                    if (monday && nextDay.DayOfWeek == DayOfWeek.Monday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_MONDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (tuesday && nextDay.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_TUESDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (wednesday && nextDay.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_WEDNESDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (thursday && nextDay.DayOfWeek == DayOfWeek.Thursday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_THURSDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (friday && nextDay.DayOfWeek == DayOfWeek.Friday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_FRIDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (saturday && nextDay.DayOfWeek == DayOfWeek.Saturday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_SATURDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                    if (sunday && nextDay.DayOfWeek == DayOfWeek.Sunday)
                    {
                        _ = _repository.CreateEntity(
                            new CourseTermDateDbo()
                            {
                                CourseTermId = courseTermId,
                                Date = nextDay,
                                DayOfWeek = "COURSE_TIMETABLE_SUNDAY",
                                TimeFromId = timeFromId,
                                TimeToId = timeToId,
                                UserInOrganizationId = Guid.Parse(lector),
                                ClassRoomId = classRoomId
                            },
                            Guid.Empty
                        );
                    }
                }
                nextDay = nextDay.AddDays(1);
            }
            return new Result();
        }

        public HashSet<CourseTermTimeTableListDto> GetTimeTable(Guid courseTermId, string culture)
        {
            return _convertor.ConvertToWebModel([.. _repository.GetEntities(false, x => x.CourseTermId == courseTermId)], culture);
        }

        public Result CancelCourseTerm(Guid courseTermTimeTableId)
        {
            _repository.DeleteEntity(courseTermTimeTableId, Guid.Empty);
            return new Result();
        }

        public Result Restore(Guid courseTermTimeTableId)
        {
            _repository.RestoreEntity(courseTermTimeTableId, Guid.Empty);
            return new Result();
        }
    }
}
