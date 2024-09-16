using Model.Edu.AttendanceStudent;
using Model.Edu.Course;
using Model.Link;
using UserService.UserProfile.MyAttendance.Dto;

namespace UserService.UserProfile.MyAttendance.Convertor
{
    public class MyAttendanceConvertor : IMyAttendanceConvertor
    {
        public Task<List<MyAttendanceListDto>> ConvertToWebModel(List<CourseStudentDbo> list, List<string> culture)
        {
            List<MyAttendanceListDto> getMyAttendanceDtos = [];
            foreach (CourseStudentDbo course in list)
            {
                List<StudentAttendanceDbo> getStudentAttendances = course
                    .AttendanceStudents.Where(x =>
                        x.CourseTermId == course.CourseTermId && x.CourseStudentId == course.UserInOrganizationId && x.IsDeleted == false
                    )
                    .ToList();
                foreach (StudentAttendanceDbo item in getStudentAttendances)
                {
                    getMyAttendanceDtos.Add(
                        new MyAttendanceListDto()
                        {
                            CourseName = course.CourseTerm.Course.CourseTranslations.FindTranslation(culture).Name,
                            IsActive = item.MyAttendance != null,
                            Date = item.CourseTermDate.Date.Value,
                            DayOfWeek = item.CourseTermDate.DayOfWeek,
                            TimeFrom = item.CourseTermDate.TimeFrom.Value,
                            TimeTo = item.CourseTermDate.TimeTo.Value
                        }
                    );
                }
            }
            return Task.FromResult(getMyAttendanceDtos.OrderByDescending(x => x.Date).ToList());
        }
    }
}
