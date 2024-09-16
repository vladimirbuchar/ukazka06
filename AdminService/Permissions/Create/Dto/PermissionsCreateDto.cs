using Core.Base.Dto;

namespace AdminService.Permissions.Create.Dto
{
    public class PermissionsCreateDto : CreateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
