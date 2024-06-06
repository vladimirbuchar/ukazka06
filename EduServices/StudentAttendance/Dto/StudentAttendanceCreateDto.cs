using Core.Base.Dto;
using System;

namespace EduServices.StudentAttendance.Dto
{
    public class StudentAttendanceCreateDto : CreateDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseTermDateId { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
