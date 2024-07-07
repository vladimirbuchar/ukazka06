using System;
using System.Text.Json.Serialization;
using Core.Base.Dto;

namespace Services.OrganizationCulture.Dto
{
    public class OrganizationCultureUpdateDto : UpdateDto
    {
        public bool IsDefault { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
    }
}
