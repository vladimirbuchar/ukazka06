using Core.Base.Dto;

namespace UserService.User.Shared.Dto
{
    public class UserTokenDto : DetailDto
    {
        public UserTokenDto()
        {
            OrganizationRole = [];
        }

        public string UserEmail { get; set; }
        public bool? IsAvatarUrl { get; set; } = false;
        public string Avatar { get; set; } = "";
        public string FullName { get; set; } = "";
        public bool UserMustChangePassword { get; set; }
        public string UserRole { get; set; }
        public Dictionary<Guid, List<string>> OrganizationRole { get; set; }
    }
}
