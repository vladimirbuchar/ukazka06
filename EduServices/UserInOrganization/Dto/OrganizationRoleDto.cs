using System;

namespace EduServices.UserInOrganization.Dto
{
    public class OrganizationRoleDto
    {
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator { get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }
        public bool IsLector { get; set; }
        public bool IsStudent { get; set; }
        public Guid UserInOrganizationRoleId { get; set; }
    }
}
