using Core.Base.Dto;

namespace EduServices.Permissions.Dto
{
    public class PermissionsDetailDto : DetailDto
    {
        public string Route { get; set; }
        public string OrganizationRole { get; set; }
    }
}
