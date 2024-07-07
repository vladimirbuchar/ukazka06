using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.UserInOrganization.Dto
{
    public class UserInOrganizationDetailDto : DetailDto
    {
        public UserInOrganizationDetailDto()
        {
            RoleId = [];
        }

        public HashSet<Guid> RoleId { get; set; }
        public HashSet<string> Role { get; set; }
    }
}
