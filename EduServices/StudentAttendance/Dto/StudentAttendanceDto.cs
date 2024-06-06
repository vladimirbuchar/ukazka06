using System;

namespace EduServices.StudentAttendance.Dto
{
    public class StudentAttendanceDto
    {
        public Guid StudentId { get; set; }
        public Guid TermId { get; set; }
        public bool IsActive { get; set; }
    }
}
