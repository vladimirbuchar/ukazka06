using Core.Base.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationUpdate.Dto
{
    public class UserInOrganizationUpdateDto : UpdateDto
    {
        public required List<Guid> OrganizationRoleId { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
