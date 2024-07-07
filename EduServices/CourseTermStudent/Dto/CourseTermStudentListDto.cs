using Core.Base.Dto;
using System;

namespace Services.CourseTermStudent.Dto
{
    public class CourseTermStudentListDto : ListDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string Email { get; set; }
        public bool CourseFinish { get; set; }
    }
}
