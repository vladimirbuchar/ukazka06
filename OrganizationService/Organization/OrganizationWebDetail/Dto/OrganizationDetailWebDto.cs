using Core.Base.Dto;

namespace OrganizationService.Organization.OrganizationWebDetail.Dto
{
    public class OrganizationDetailWebDto : DetailDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WWW { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
