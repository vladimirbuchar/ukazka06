using System;
using System.Collections.Generic;
using Core.Base.Dto;

namespace EduServices.UserInOrganization.Dto
{
    public class UserInOrganizationListDto : ListDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Format("{0} {1} {2}", FirstName, SecondName, LastName);
        public string UserEmail { get; set; }
        public List<string> UserRole { get; set; }
        public Guid UserInOrganizationId { get; set; }
    }
}
