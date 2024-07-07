using System;
using System.Text.Json.Serialization;
using Core.Base.Dto;

namespace Services.StudentInGroup.Dto
{
    public class StudentInGroupCreateDto : CreateDto
    {
        [JsonIgnore]
        public Guid OrganizationId { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid StudentGroupId { get; set; }
    }

    public class StudentInGroupCreate { }
}
