using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.UserInOrganization.Dto
{
    public class UserInOrganizationUpdateDto : UpdateDto
    {
        public List<Guid> OrganizationRoleId { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
