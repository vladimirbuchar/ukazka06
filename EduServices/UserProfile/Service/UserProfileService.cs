using Core.Base.Service;
using EduRepository.AttendanceStudentRepository;
using EduRepository.CourseLectorRepository;
using EduRepository.CourseRepository;
using EduRepository.CourseStudentRepository;
using EduRepository.OrganizationHoursRepository;
using EduRepository.UserCertificateRepository;
using EduRepository.UserInOrganizationRepository;
using EduServices.Organization.Dto;
using EduServices.OrganizationStudyHour.Dto;
using EduServices.User.Dto;
using EduServices.UserProfile.Convertor;
using EduServices.UserProfile.Dto;
using Model.Tables.Edu.AttendanceStudent;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.OrganizationStudyHour;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.UserProfile.Service
{
    public class UserProfileService(
        IUserProfileConvertor convertor,
        IUserCertificateRepository userCertificateRepository,
        ICourseStudentRepository courseStudentRepository,
        ICourseLectorRepository courseLectorRepository,
        IOrganizationStudyHourRepository organizationStudyHourRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        ICourseRepository courseRepository,
        IStudentAttendanceRepository atendanceStudentRepository
    ) : BaseService<IUserProfileConvertor>(convertor), IUserProfileService
    {
        private readonly IUserCertificateRepository _userCertificateRepository = userCertificateRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly IOrganizationStudyHourRepository _organizationStudyHourRepository = organizationStudyHourRepository;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IStudentAttendanceRepository _attendanceStudentRepository = atendanceStudentRepository;

        public HashSet<MyCertificateListDto> GetMyCertificate(Guid userId)
        {
            return _convertor.ConvertToWebModel([.. _userCertificateRepository.GetEntities(false, x => x.UserId == userId).OrderByDescending(x => x.ActiveFrom)]);
        }

        public HashSet<MyCourseListDto> GetMyCourse(Guid userId, bool hideFinishCourse, string culture)
        {
            HashSet<MyCourseListDto> myCourse = [];
            HashSet<MyCourseListDto> study = _convertor.ConvertToWebModel(_courseStudentRepository.GetStudentCourse(userId, hideFinishCourse), culture);
            foreach (MyCourseListDto item in study)
            {
                item.IsStudent = true;
            }
            HashSet<MyCourseListDto> lector = _convertor.ConvertToWebModel(_courseLectorRepository.GetLectorCourse(userId), culture);
            foreach (MyCourseListDto item in lector)
            {
                item.IsLector = true;
            }
            myCourse.UnionWith(study);
            myCourse.UnionWith(lector);
            myCourse = [.. myCourse.OrderBy(x => x.CourseFinish).ThenBy(x => x.CourseName)];
            return myCourse;
        }

        public List<MyTimeTableListDto> GetMyTimeTable(Guid userId, string culture)
        {
            List<MyTimeTableListDto> getUserDetailDtos = [];
            HashSet<UserInOrganizationDbo> organizations = _userInOrganizationRepository.GetEntities(false, x => x.UserId == userId && (x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR));
            HashSet<CourseStudentDbo> myCourse = _courseStudentRepository.GetStudentCourse(userId, true);
            HashSet<CourseLectorDbo> myCourseLector = _courseLectorRepository.GetLectorCourse(userId);

            foreach (UserInOrganizationDbo item in organizations)
            {
                HashSet<CourseStudentDbo> courseInOrganization = myCourse.Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id).ToHashSet();
                MyTimeTableListDto timeTableItem = new();
                HashSet<OrganizationStudyHourDbo> getStudyHours = [.. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == item.Id).OrderBy(x => x.Position)];
                HashSet<TimeTableDto> timeTable = [];
                HashSet<CourseStudentDbo> monday = courseInOrganization.Where(x => x.CourseTerm.Monday).ToHashSet();
                HashSet<CourseStudentDbo> tuesday = courseInOrganization.Where(x => x.CourseTerm.Tuesday).ToHashSet();
                HashSet<CourseStudentDbo> wednesday = courseInOrganization.Where(x => x.CourseTerm.Wednesday).ToHashSet();
                HashSet<CourseStudentDbo> thursday = courseInOrganization.Where(x => x.CourseTerm.Thursday).ToHashSet();
                HashSet<CourseStudentDbo> friday = courseInOrganization.Where(x => x.CourseTerm.Friday).ToHashSet();
                HashSet<CourseStudentDbo> saturday = courseInOrganization.Where(x => x.CourseTerm.Saturday).ToHashSet();
                HashSet<CourseStudentDbo> sunday = courseInOrganization.Where(x => x.CourseTerm.Sunday).ToHashSet();

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
                    .ToHashSet();
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
                HashSet<CourseLectorDbo> courseInOrganization = myCourseLector.Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id).ToHashSet();
                MyTimeTableListDto timeTableItem = new();
                HashSet<OrganizationStudyHourDbo> getStudyHours = [.. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == item.Id).OrderBy(x => x.Position)];
                HashSet<TimeTableDto> timeTable = [];
                HashSet<CourseLectorDbo> monday = courseInOrganization.Where(x => x.CourseTerm.Monday).ToHashSet();
                HashSet<CourseLectorDbo> tuesday = courseInOrganization.Where(x => x.CourseTerm.Tuesday).ToHashSet();
                HashSet<CourseLectorDbo> wednesday = courseInOrganization.Where(x => x.CourseTerm.Wednesday).ToHashSet();
                HashSet<CourseLectorDbo> thursday = courseInOrganization.Where(x => x.CourseTerm.Thursday).ToHashSet();
                HashSet<CourseLectorDbo> friday = courseInOrganization.Where(x => x.CourseTerm.Friday).ToHashSet();
                HashSet<CourseLectorDbo> saturday = courseInOrganization.Where(x => x.CourseTerm.Saturday).ToHashSet();
                HashSet<CourseLectorDbo> sunday = courseInOrganization.Where(x => x.CourseTerm.Sunday).ToHashSet();

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
                    .ToHashSet();
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

        private static void PrepareTimeTable(HashSet<CourseStudentDbo> day, HashSet<OrganizationStudyHourDbo> getStudyHours, MyTimeTableListDto timeTableItem, string dayName, string culture)
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
            _ = timeTableItem.TimeTable.Add(timeTableDto);
        }

        private static void PrepareTimeTable(HashSet<CourseLectorDbo> day, HashSet<OrganizationStudyHourDbo> getStudyHours, MyTimeTableListDto timeTableItem, string dayName, string culture)
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
            _ = timeTableItem.TimeTable.Add(timeTableDto);
        }

        public HashSet<MyAttendanceListDto> GetMyAttendance(Guid userId, string culture)
        {
            HashSet<MyAttendanceListDto> getMyAttendanceDtos = [];
            HashSet<CourseStudentDbo> myCourse = _courseStudentRepository.GetStudentCourse(userId, true);

            foreach (CourseStudentDbo course in myCourse)
            {
                HashSet<StudentAttendanceDbo> getStudentAttendances = _attendanceStudentRepository
                    .GetEntities(false, x => x.CourseTermId == course.CourseTermId)
                    .Where(x => x.CourseStudentId == course.UserInOrganizationId)
                    .ToHashSet();
                foreach (StudentAttendanceDbo item in getStudentAttendances)
                {
                    StudentAttendanceDbo myAttendances = _attendanceStudentRepository.GetEntity(false, x => x.CourseStudentId == item.CourseStudentId && x.CourseTermDateId == item.CourseTermDateId);

                    _ = getMyAttendanceDtos.Add(
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

        public HashSet<ManagedCourseListDto> GetManagedCourse(Guid userId)
        {
            HashSet<UserInOrganizationDbo> org = _userInOrganizationRepository
                .GetEntities(false, x => x.UserId == userId)
                .Where(x =>
                    x.OrganizationRole.SystemIdentificator
                        is Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                            or Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                            or Core.Constants.OrganizationRole.COURSE_EDITOR
                            or Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                )
                .ToHashSet();
            HashSet<ManagedCourseListDto> data = [];

            foreach (UserInOrganizationDbo item in org)
            {
                HashSet<CourseDbo> courses = _courseRepository.GetEntities(false, x => x.OrganizationId == item.Id);
                foreach (CourseDbo course in courses)
                {
                    _ = data.Add(
                        new ManagedCourseListDto()
                        {
                            CourseName = course.CourseTranslations.FindTranslation("").Name,
                            Id = course.Id,
                            OrganizationId = item.Id,
                            IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,

                            IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                            IsOrganizationAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                        }
                    );
                }
            }
            return data;
        }

        public HashSet<MyOrganizationListDto> GetMyOrganization(Guid userId)
        {
            return _convertor.ConvertToWebModel(_userInOrganizationRepository.GetEntities(false, x => x.UserId == userId));
        }
    }
}
