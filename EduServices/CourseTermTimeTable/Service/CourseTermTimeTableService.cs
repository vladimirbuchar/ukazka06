﻿using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseTerm;
using Model.Edu.CourseTermDate;
using Repository.CourseLectorRepository;
using Repository.CourseTermDateRepository;
using Repository.CourseTermRepository;
using Services.CourseTermTimeTable.Convertor;
using Services.CourseTermTimeTable.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseTermTimeTable.Service
{
    public class CourseTermTimeTableService(
        ICourseTermDateRepository courseTermDateRepository,
        ICourseLectorRepository courseLectorRepository,
        ICourseTermRepository courseTermRepository,
        ICourseTermTimeTableConvertor convertor
    )
        : BaseService<ICourseTermDateRepository, CourseTermDateDbo, ICourseTermTimeTableConvertor>(courseTermDateRepository, convertor),
            ICourseTermTimeTableService
    {
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public async Task<Result> GenerateTimeTable(Guid courseTermId)
        {
            CourseTermDbo getCourseTermDetail = await _courseTermRepository.GetEntity(courseTermId);
            List<CourseTermDateDbo> getTimeTables = await _repository
                .GetEntities(false, x => x.CourseTermId == courseTermId && x.Date >= DateTime.Now);
            foreach (CourseTermDateDbo item in getTimeTables)
            {
                await _repository.DeleteEntity(item.Id, Guid.Empty);
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
                (await _courseLectorRepository
                    .GetEntities(false, x => x.CourseTermId == courseTermId))
                    .Select(x => x.UserInOrganizationId.ToString())
                    .ToList(),
                getCourseTermDetail.ClassRoomId
            );
            return new Result();
        }

        public async Task<Result> GenerateTimeTable(
            DateTime activeFrom,
            DateTime activeTo,
            Guid timeFromId,
            Guid timeToId,
            List<bool> days,
            Guid courseTermId,
            List<string> lectors,
            Guid classRoomId
        )
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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
                        _ = await _repository.CreateEntity(
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

        public async Task<List<CourseTermTimeTableListDto>> GetTimeTable(Guid courseTermId, string culture)
        {
            return _convertor.ConvertToWebModel([.. await _repository.GetEntities(false, x => x.CourseTermId == courseTermId)], culture);
        }

        public async Task<Result> CancelCourseTerm(Guid courseTermTimeTableId)
        {
            await _repository.DeleteEntity(courseTermTimeTableId, Guid.Empty);
            return new Result();
        }

        public async Task<Result> Restore(Guid courseTermTimeTableId)
        {
            await _repository.RestoreEntity(courseTermTimeTableId, Guid.Empty);
            return new Result();
        }
    }
}
