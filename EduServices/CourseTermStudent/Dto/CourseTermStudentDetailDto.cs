using System;
using Core.Base.Dto;

namespace EduServices.CourseTermStudent.Dto
{
    public class CourseTermStudentDetailDto : DetailDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string Email { get; set; }
        public bool CourseFinish { get; set; }
    }
}
