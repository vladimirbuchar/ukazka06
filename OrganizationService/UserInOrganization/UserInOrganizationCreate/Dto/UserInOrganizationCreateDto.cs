using Core.Base.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationCreate.Dto
{
    public class UserInOrganizationCreateDto : CreateDto
    {
        public required List<string> UserEmails { get; set; }
        public Guid OrganizationId { get; set; }
        public required List<Guid> OrganizationRoleId { get; set; }
    }

    public class AddUserToOrganization : CreateDto
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public required List<Guid> OrganizationRoleId { get; set; }
    }
}
