using Core.Base.Filter;

namespace OrganizationService.UserInOrganization.UserInOrganizationList.Filter
{
    public class UserInOrganizationFilter : RequestFilter
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public required List<string> UserRole { get; set; }
    }
}
