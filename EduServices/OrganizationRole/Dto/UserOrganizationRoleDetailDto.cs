using Core.Base.Dto;

namespace Services.OrganizationRole.Dto
{
    public class UserOrganizationRoleDetailDto : ListDto
    {
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator { get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }
        public bool IsLector { get; set; }
        public bool IsStudent { get; set; }
    }
}
