using Core.Base.Dto;
using System;
using System.Text.Json.Serialization;

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

    public class StudentInGroupCreate
    {

    }
}
