using System;
using Core.Base.Dto;

namespace Services.StudentAttendance.Dto
{
    public class StudentAttendanceCreateDto : CreateDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseTermDateId { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
