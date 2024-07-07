using Core.Base.Dto;
using System;
using System.Collections.Generic;

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
