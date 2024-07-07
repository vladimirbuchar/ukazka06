using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.UserInOrganization.Dto
{
    public class UserInOrganizationCreateDto : CreateDto
    {
        public List<string> UserEmails { get; set; }
        public Guid OrganizationId { get; set; }
        public List<Guid> OrganizationRoleId { get; set; }
    }
}
