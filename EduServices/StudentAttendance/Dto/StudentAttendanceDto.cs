using System;

namespace Services.StudentAttendance.Dto
{
    public class StudentAttendanceDto
    {
        public Guid StudentId { get; set; }
        public Guid TermId { get; set; }
        public bool IsActive { get; set; }
    }
}
