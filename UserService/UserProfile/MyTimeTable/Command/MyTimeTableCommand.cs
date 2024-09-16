using Core.Base.Command;
using Model.Edu.Course;
using Model.Edu.OrganizationStudyHour;
using Model.Link;
using Repository.UserInOrganization;
using UserService.User.Dto;
using UserService.UserProfile.MyTimeTable.Dto;

namespace UserService.UserProfile.MyTimeTable.Command
{
    public class MyTimeTableCommand : BaseCommand<IUserInOrganizationRepository>, IMyTimeTableCommand
    {
        public MyTimeTableCommand(IUserInOrganizationRepository repository) : base(repository)
        {
        }

        public async Task<List<MyTimeTableListDto>> Execute(Guid userId, List<string> culture)
        {
            List<MyTimeTableListDto> getUserDetailDtos = [];
            List<UserInOrganizationDbo> organizations = await _repository.GetEntities(
                false,
                x =>
                    x.UserId == userId
                    && (
                        x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR
                    )
            );

            foreach (UserInOrganizationDbo item in organizations)
            {
                List<CourseStudentDbo> courseInOrganization = item.CourseStudents.Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id && x.UserInOrganization.UserId == userId && x.CourseFinish == true).ToList();
                MyTimeTableListDto timeTableItem = new();
                List<OrganizationStudyHourDbo> getStudyHours = item.Organization.OrganizationStudyHours.OrderBy(x => x.Position).ToList();
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
                List<CourseLectorDbo> courseInOrganization = item.CourseLectors
                    .Where(x => x.CourseTerm.ClassRoom.Branch.OrganizationId == item.Id && x.UserInOrganization.UserId == userId)
                    .ToList();
                MyTimeTableListDto timeTableItem = new();
                List<OrganizationStudyHourDbo> getStudyHours = item.Organization.OrganizationStudyHours.OrderBy(x => x.Position).ToList();

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
            List<string> culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string? courseName = "";
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
            List<string> culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string? courseName = "";
                courseName = day.FirstOrDefault(x => x.CourseTerm.TimeFromId == item.ActiveFromId && x.CourseTerm.TimeToId == item.ActiveToId)
                    ?.CourseTerm.Course.CourseTranslations.FindTranslation(culture)
                    .Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }
    }
}
