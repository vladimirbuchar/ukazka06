using Core.Base.Dto;
using System;

namespace Services.UserProfile.Dto
{
    public class ManagedCourseListDto : ListDto
    {
        public string CourseName { get; set; }
        public Guid OrganizationId { get; set; }
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator { get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }
    }
}
