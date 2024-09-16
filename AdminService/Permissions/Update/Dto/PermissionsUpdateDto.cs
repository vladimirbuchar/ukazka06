using Core.Base.Dto;

namespace AdminService.Permissions.Update.Dto
{
    public class PermissionsUpdateDto : UpdateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
