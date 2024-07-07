using System;

namespace Services.StudentAttendance.Dto
{
    public class StudentInCourseTermDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string UserEmail { get; set; }
        public bool CourseFinish { get; set; }
    }
}
