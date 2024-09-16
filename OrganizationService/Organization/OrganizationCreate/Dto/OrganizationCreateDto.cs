using Core.Base.Dto;
using Core.DataTypes;
using System.Text.Json.Serialization;

namespace OrganizationService.Organization.OrganizationCreate.Dto
{
    public class OrganizationCreateDto : CreateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Guid OranizationRoleOwnerId { get; set; }

        [JsonIgnore]
        public Guid LicenceId { get; set; }

        [JsonIgnore]
        public string? ElearningUrl { get; set; }
        [JsonIgnore]
        public string? UserDefaultPassword { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WWW { get; set; }
        public required List<Address> Addresses { get; set; }
        public string? Name { get; set; }
        public Guid DefaultCultureId { get; set; }
    }
}
