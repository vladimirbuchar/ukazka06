using System.Collections.Generic;
using Core.Base.Dto;
using Services.CourseTermTimeTable.Dto;

namespace Services.StudentAttendance.Dto
{
    public class StudentAttendanceDetailDto : DetailDto
    {
        public StudentAttendanceDetailDto()
        {
            TimeTable = [];
            Student = [];
            StudentAttendance = [];
        }

        public HashSet<CourseTermTimeTableListDto> TimeTable { get; set; }
        public HashSet<StudentInCourseTermDto> Student { get; set; }
        public HashSet<StudentAttendanceDto> StudentAttendance { get; set; }
    }
}
