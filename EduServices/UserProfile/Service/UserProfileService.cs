using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Service;
using Model.Edu.AttendanceStudent;
using Model.Edu.Course;
using Model.Edu.OrganizationStudyHour;
using Model.Link;
using Repository.AttendanceStudentRepository;
using Repository.CourseLectorRepository;
using Repository.CourseRepository;
using Repository.CourseStudentRepository;
using Repository.OrganizationHoursRepository;
using Repository.StudentEvaluationRepository;
using Repository.UserCertificateRepository;
using Repository.UserInOrganizationRepository;
using Services.Organization.Dto;
using Services.OrganizationStudyHour.Dto;
using Services.StudentEvaluation.Dto;
using Services.User.Dto;
using Services.UserProfile.Convertor;
using Services.UserProfile.Dto;

namespace Services.UserProfile.Service
{
    public class UserProfileService(
        IUserProfileConvertor convertor,
        IUserCertificateRepository userCertificateRepository,
        ICourseStudentRepository courseStudentRepository,
        ICourseLectorRepository courseLectorRepository,
        IOrganizationStudyHourRepository organizationStudyHourRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        ICourseRepository courseRepository,
        IAttendanceStudentRepository atendanceStudentRepository,
        IStudentEvaluationRepository studentEvaluationRepository
    ) : BaseService<IUserProfileConvertor>(convertor), IUserProfileService
    {
        private readonly IUserCertificateRepository _userCertificateRepository = userCertificateRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly IOrganizationStudyHourRepository _organizationStudyHourRepository = organizationStudyHourRepository;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IAttendanceStudentRepository _attendanceStudentRepository = atendanceStudentRepository;
        private readonly IStudentEvaluationRepository _studentEvaluationRepository = studentEvaluationRepository;

        public List<MyCertificateListDto> GetMyCertificate(Guid userId)
        {
            return _convertor.ConvertToWebModel(
                [.. _userCertificateRepository.GetEntities(false, x => x.UserId == userId, null, x => x.ActiveFrom).Result]
            );
        }

        public List<MyCourseListDto> GetMyCourse(Guid userId, bool hideFinishCourse, string culture)
        {
            List<MyCourseListDto> myCourse = [];
            List<MyCourseListDto> study = _convertor.ConvertToWebModel(_courseStudentRepository.GetStudentCourse(userId, hideFinishCourse), culture);
            foreach (MyCourseListDto item in study)
            {
                item.IsStudent = true;
            }
            List<MyCourseListDto> lector = _convertor.ConvertToWebModel(
                _courseLectorRepository.GetEntities(false, x => x.UserInOrganization.UserId == userId).Result,
                culture
            );
            foreach (MyCourseListDto item in lector)
            {
                item.IsLector = true;
            }
            myCourse.AddRange(study);
            myCourse.AddRange(lector);
            myCourse = [.. myCourse.OrderBy(x => x.CourseFinish).ThenBy(x => x.CourseName)];
            return myCourse;
        }

        public List<MyTimeTableListDto> GetMyTimeTable(Guid userId, string culture)
        {
            List<MyTimeTableListDto> getUserDetailDtos = [];
            List<UserInOrganizationDbo> organizations = _userInOrganizationRepository
                .GetEntities(
                    false,
                    x =>
                        x.UserId == userId
                        && (
                            x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT
                            || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR
                        )
                )
                .Result;
            List<CourseStudentDbo> myCourse = _courseStudentRepository.GetStudentCourse(userId, true).ToList();
            List<CourseLectorDbo> myCourseLector = _courseLectorRepository.GetEntities(false, x => x.UserInOrganization.UserId == userId).Result;

            foreach (UserInOrganizationDbo item in organizations)
            {
                List<CourseStudentDbo> courseInOrganization = myCourse.Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id).ToList();
                MyTimeTableListDto timeTableItem = new();
                List<OrganizationStudyHourDbo> getStudyHours =
                [
                    .. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == item.Id, null, x => x.Position).Result
                ];
                List<TimeTableDto> timeTable = [];
                List<CourseStudentDbo> monday = courseInOrganization.Where(x => x.CourseTerm.Monday).ToList();
                List<CourseStudentDbo> tuesday = courseInOrganization.Where(x => x.CourseTerm.Tuesday).ToList();
                List<CourseStudentDbo> wednesday = courseInOrganization.Where(x => x.CourseTerm.Wednesday).ToList();
                List<CourseStudentDbo> thursday = courseInOrganization.Where(x => x.CourseTerm.Thursday).ToList();
                List<CourseStudentDbo> friday = courseInOrganization.Where(x => x.CourseTerm.Friday).ToList();
                List<CourseStudentDbo> saturday = courseInOrganization.Where(x => x.CourseTerm.Saturday).ToList();
                List<CourseStudentDbo> sunday = courseInOrganization.Where(x => x.CourseTerm.Sunday).ToList();

                timeTableItem.StudyHours = getStudyHours
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
                timeTableItem.HaveStudyHours = getStudyHours.Count > 0;
                timeTableItem.OrganizationName = item.Organization.Name;
                PrepareTimeTable(monday, getStudyHours, timeTableItem, "TIME_TABLE_MONDAY", culture);
                PrepareTimeTable(tuesday, getStudyHours, timeTableItem, "TIME_TABLE_TUESDAY", culture);
                PrepareTimeTable(wednesday, getStudyHours, timeTableItem, "TIME_TABLE_WEDNESDAY", culture);
                PrepareTimeTable(thursday, getStudyHours, timeTableItem, "TIME_TABLE_THURSDAY", culture);
                PrepareTimeTable(friday, getStudyHours, timeTableItem, "TIME_TABLE_FRIDAY", culture);
                PrepareTimeTable(saturday, getStudyHours, timeTableItem, "TIME_TABLE_SATURDAY", culture);
                PrepareTimeTable(sunday, getStudyHours, timeTableItem, "TIME_TABLE_SUNDAY", culture);
                getUserDetailDtos.Add(timeTableItem);
            }

            foreach (UserInOrganizationDbo item in organizations)
            {
                List<CourseLectorDbo> courseInOrganization = myCourseLector
                    .Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id)
                    .ToList();
                MyTimeTableListDto timeTableItem = new();
                List<OrganizationStudyHourDbo> getStudyHours =
                [
                    .. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == item.Id, null, x => x.Position).Result
                ];
                List<TimeTableDto> timeTable = [];
                List<CourseLectorDbo> monday = courseInOrganization.Where(x => x.CourseTerm.Monday).ToList();
                List<CourseLectorDbo> tuesday = courseInOrganization.Where(x => x.CourseTerm.Tuesday).ToList();
                List<CourseLectorDbo> wednesday = courseInOrganization.Where(x => x.CourseTerm.Wednesday).ToList();
                List<CourseLectorDbo> thursday = courseInOrganization.Where(x => x.CourseTerm.Thursday).ToList();
                List<CourseLectorDbo> friday = courseInOrganization.Where(x => x.CourseTerm.Friday).ToList();
                List<CourseLectorDbo> saturday = courseInOrganization.Where(x => x.CourseTerm.Saturday).ToList();
                List<CourseLectorDbo> sunday = courseInOrganization.Where(x => x.CourseTerm.Sunday).ToList();

                timeTableItem.StudyHours = getStudyHours
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
                timeTableItem.HaveStudyHours = getStudyHours.Count > 0;
                timeTableItem.OrganizationName = item.Organization.Name;
                PrepareTimeTable(monday, getStudyHours, timeTableItem, "TIME_TABLE_MONDAY", culture);
                PrepareTimeTable(tuesday, getStudyHours, timeTableItem, "TIME_TABLE_TUESDAY", culture);
                PrepareTimeTable(wednesday, getStudyHours, timeTableItem, "TIME_TABLE_WEDNESDAY", culture);
                PrepareTimeTable(thursday, getStudyHours, timeTableItem, "TIME_TABLE_THURSDAY", culture);
                PrepareTimeTable(friday, getStudyHours, timeTableItem, "TIME_TABLE_FRIDAY", culture);
                PrepareTimeTable(saturday, getStudyHours, timeTableItem, "TIME_TABLE_SATURDAY", culture);
                PrepareTimeTable(sunday, getStudyHours, timeTableItem, "TIME_TABLE_SUNDAY", culture);
                getUserDetailDtos.Add(timeTableItem);
            }
            return getUserDetailDtos;
        }

        private static void PrepareTimeTable(
            List<CourseStudentDbo> day,
            List<OrganizationStudyHourDbo> getStudyHours,
            MyTimeTableListDto timeTableItem,
            string dayName,
            string culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.CourseTerm.TimeFromId == item.ActiveFromId && x.CourseTerm.TimeToId == item.ActiveToId)
                    ?.CourseTerm.Course.CourseTranslations.FindTranslation(culture)
                    .Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }

        private static void PrepareTimeTable(
            List<CourseLectorDbo> day,
            List<OrganizationStudyHourDbo> getStudyHours,
            MyTimeTableListDto timeTableItem,
            string dayName,
            string culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.CourseTerm.TimeFromId == item.ActiveFromId && x.CourseTerm.TimeToId == item.ActiveToId)
                    ?.CourseTerm.Course.CourseTranslations.FindTranslation(culture)
                    .Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }

        public List<MyAttendanceListDto> GetMyAttendance(Guid userId, string culture)
        {
            List<MyAttendanceListDto> getMyAttendanceDtos = [];
            List<CourseStudentDbo> myCourse = _courseStudentRepository.GetStudentCourse(userId, true);

            foreach (CourseStudentDbo course in myCourse)
            {
                List<AttendanceStudentDbo> getStudentAttendances = _attendanceStudentRepository
                    .GetEntities(false, x => x.CourseTermId == course.CourseTermId)
                    .Result.Where(x => x.CourseStudentId == course.UserInOrganizationId)
                    .ToList();
                foreach (AttendanceStudentDbo item in getStudentAttendances)
                {
                    AttendanceStudentDbo myAttendances = _attendanceStudentRepository.GetEntity(
                        false,
                        x => x.CourseStudentId == item.CourseStudentId && x.CourseTermDateId == item.CourseTermDateId
                    );

                    getMyAttendanceDtos.Add(
                        new MyAttendanceListDto()
                        {
                            CourseName = course.CourseTerm.Course.CourseTranslations.FindTranslation(culture).Name,
                            IsActive = myAttendances != null,
                            Date = item.CourseTermDate.Date,
                            DayOfWeek = item.CourseTermDate.DayOfWeek,
                            TimeFrom = item.CourseTermDate.TimeFrom.Value,
                            TimeTo = item.CourseTermDate.TimeTo.Value
                        }
                    );
                }
            }
            return [.. getMyAttendanceDtos.OrderByDescending(x => x.Date)];
        }

        public List<ManagedCourseListDto> GetManagedCourse(Guid userId)
        {
            List<UserInOrganizationDbo> org = _userInOrganizationRepository
                .GetEntities(false, x => x.UserId == userId)
                .Result.Where(x =>
                    x.OrganizationRole.SystemIdentificator
                        is Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                            or Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                            or Core.Constants.OrganizationRole.COURSE_EDITOR
                            or Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                )
                .ToList();
            List<ManagedCourseListDto> data = [];

            foreach (UserInOrganizationDbo item in org)
            {
                List<CourseDbo> courses = _courseRepository.GetEntities(false, x => x.OrganizationId == item.Id).Result;
                foreach (CourseDbo course in courses)
                {
                    data.Add(
                        new ManagedCourseListDto()
                        {
                            CourseName = course.CourseTranslations.FindTranslation("").Name,
                            Id = course.Id,
                            OrganizationId = item.Id,
                            IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,

                            IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                            IsOrganizationAdministrator =
                                item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                        }
                    );
                }
            }
            return data;
        }

        public List<MyOrganizationListDto> GetMyOrganization(Guid userId)
        {
            return _convertor.ConvertToWebModel(_userInOrganizationRepository.GetEntities(false, x => x.UserId == userId).Result);
        }

        public List<MyEvaluationListDto> GetMyEvaluation(Guid id)
        {
            return _convertor.ConvertToWebModel(
                _studentEvaluationRepository.GetEntities(false, x => x.CourseStudent.UserInOrganization.UserId == id).Result
            );
        }
    }
}
