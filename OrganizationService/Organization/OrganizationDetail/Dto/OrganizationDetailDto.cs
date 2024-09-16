using Core.Base.Dto;
using Core.DataTypes;

namespace OrganizationService.Organization.OrganizationDetail.Dto
{
    public class OrganizationDetailDto : DetailDto
    {
        public Guid LicenseId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WWW { get; set; }
        public string? Name { get; set; }
        public required List<Address> Addresses { get; set; }
        public string? Logo { get; set; }
    }
}
