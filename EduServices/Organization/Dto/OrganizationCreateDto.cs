using System;

namespace EduServices.Organization.Dto
{
    public class OrganizationCreateDto : OrganizationCreateByUserDto
    {
        public Guid UserId { get; set; }
    }
}
