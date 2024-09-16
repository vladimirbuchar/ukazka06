using Core.Base.Dto;

namespace AdminService.Permissions.List.Dto
{
    public class PermissionsListDto : ListDto
    {
        public string? Route { get; set; }
        public string? OrganizationRole { get; set; }
    }
}
