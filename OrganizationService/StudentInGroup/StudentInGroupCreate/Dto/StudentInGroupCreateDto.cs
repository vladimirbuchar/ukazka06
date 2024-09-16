using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace OrganizationService.StudentInGroup.StudentInGroupCreate.Dto
{
    public class StudentInGroupCreateDto : CreateDto
    {
        [JsonIgnore]
        public Guid OrganizationId { get; set; }
        public string? UserEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SecondName { get; set; }
        public Guid StudentGroupId { get; set; }
    }

    public class AddStudentToStudentGroup : CreateDto
    {
        public Guid UserInOrganizationId { get; set; }
        public Guid StudentGroupId { get; set; }
    }
}
