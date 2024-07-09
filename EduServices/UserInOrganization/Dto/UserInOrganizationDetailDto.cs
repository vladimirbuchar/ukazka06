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

        public List<Guid> RoleId { get; set; }
        public List<string> Role { get; set; }
    }
}
