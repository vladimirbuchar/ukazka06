using System;
using System.Text.Json.Serialization;
using Core.Base.Dto;
using Services.Organization.Dto;

namespace Services.User.Dto
{
    public class UserCreateDto : CreateDto
    {
        public UserCreateDto()
        {
            Organization = new OrganizationCreateDto();
        }

        public string UserPassword { get; set; }
        public string UserPassword2 { get; set; }
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; } = new PersonDto();
        public bool CreateNewOrganization { get; set; }
        public OrganizationCreateByUserDto Organization { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; } = Guid.Empty;

        [JsonIgnore]
        public bool SendActivateEmail { get; set; } = false;

        [JsonIgnore]
        public bool AllowClassicLogin { get; set; } = true;
    }
}
