using Core.Base.Dto;

namespace UserService.UserProfile.MyOrganization.Dto
{
    public class MyOrganizationListDto : ListDto
    {
        public MyOrganizationListDto()
        {
            OrganizationRole = [];
        }

        public string Name { get; set; }
        public List<OrganizationRoleDto> OrganizationRole { get; set; }
    }
}
