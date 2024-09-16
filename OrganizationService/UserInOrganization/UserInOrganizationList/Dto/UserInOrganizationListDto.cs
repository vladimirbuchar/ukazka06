using Core.Base.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationList.Dto
{
    public class UserInOrganizationListDto : ListDto
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public required List<string> UserRole { get; set; }
        public Guid UserInOrganizationId { get; set; }
    }
}
