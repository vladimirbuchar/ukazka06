using System;
using Core.Base.Dto;

namespace EduServices.StudentInGroup.Dto
{
    public class StudentInGroupListDto : ListDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string Email { get; set; }
    }
}
