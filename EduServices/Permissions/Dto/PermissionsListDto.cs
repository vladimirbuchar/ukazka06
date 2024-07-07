using Core.Base.Dto;

namespace Services.Permissions.Dto
{
    public class PermissionsListDto : ListDto
    {
        public string Route { get; set; }
        public string OrganizationRole { get; set; }

    }
}
