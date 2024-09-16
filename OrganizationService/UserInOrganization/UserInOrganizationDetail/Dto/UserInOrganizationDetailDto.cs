using Core.Base.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationDetail.Dto
{
    public class UserInOrganizationDetailDto : DetailDto
    {
        public UserInOrganizationDetailDto()
        {
            RoleId = [];
        }

        public List<Guid> RoleId { get; set; }
        public List<string> Role { get; set; }
    }
}
