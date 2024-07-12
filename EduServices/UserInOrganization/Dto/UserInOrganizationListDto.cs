using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace Services.UserInOrganization.Dto
{
    public class UserInOrganizationListDto : ListDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public List<string> UserRole { get; set; }
        public Guid UserInOrganizationId { get; set; }
    }
}
