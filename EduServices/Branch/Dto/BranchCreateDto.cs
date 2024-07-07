using Core.Base.Dto;
using System;
using System.Text.Json.Serialization;

namespace Services.Branch.Dto
{
    public class BranchCreateDto : CreateDto
    {
        public Guid? CountryId { get; set; } = Guid.Empty;
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
        public bool IsMainBranch { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public bool IsOnline { get; set; } = false;
        public Guid OrganizationId { get; set; }

    }

}
