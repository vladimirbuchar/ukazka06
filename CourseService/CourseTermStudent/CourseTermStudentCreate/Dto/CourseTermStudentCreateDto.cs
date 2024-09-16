using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Dto
{
    public class CourseTermStudentCreateDto : CreateDto
    {
        public string? UserEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid CourseTermId { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
    }

    public class AddCourseTermStudentDto : CreateDto
    {
        public Guid CourseTermId { get; set; }
        public Guid UserInOrganizationId { get; set; }
    }
}
