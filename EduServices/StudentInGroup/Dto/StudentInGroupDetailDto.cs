using System;
using Core.Base.Dto;

namespace Services.StudentInGroup.Dto
{
    public class StudentInGroupDetailDto : DetailDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string Email { get; set; }
    }
}
