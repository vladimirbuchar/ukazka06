using System;
using System.Text.Json.Serialization;

namespace EduServices.Organization.Dto
{
    public class OrganizationCreateDto : OrganizationCreateByUserDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
