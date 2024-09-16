using Core.Base.Dto;

namespace CourseStudyService.StudentAttendance.StudentAttendanceList.Dto
{
    public class StudentAttendanceListDto : ListDto
    {
        public StudentAttendanceListDto()
        {
            TimeTable = [];
            Student = [];
            StudentAttendance = [];
        }

        public List<CourseTermTimeTableListDto> TimeTable { get; set; }
        public List<StudentInCourseTermDto> Student { get; set; }
        public List<StudentAttendanceDto> StudentAttendance { get; set; }
    }
}
