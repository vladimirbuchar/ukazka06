using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto
{
    public class OrganizationCultureUpdateDto : UpdateDto
    {
        public bool IsDefault { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
    }
}
