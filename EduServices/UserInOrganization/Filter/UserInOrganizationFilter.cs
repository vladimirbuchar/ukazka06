using System.Collections.Generic;
using Core.Base.Filter;

namespace Services.UserInOrganization.Filter
{
    public class UserInOrganizationFilter : FilterRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public List<string> UserRole { get; set; }
    }
}
