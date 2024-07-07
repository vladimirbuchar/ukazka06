using System;
using System.Text.Json.Serialization;

namespace Services.Organization.Dto
{
    public class OrganizationCreateDto : OrganizationCreateByUserDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
