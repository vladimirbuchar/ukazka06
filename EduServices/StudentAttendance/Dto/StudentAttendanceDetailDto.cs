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

        public List<CourseTermTimeTableListDto> TimeTable { get; set; }
        public List<StudentInCourseTermDto> Student { get; set; }
        public List<StudentAttendanceDto> StudentAttendance { get; set; }
    }
}
