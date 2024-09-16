using Core.Base.Dto;
using Core.DataTypes;

namespace OrganizationService.Organization.OrganizationUpdate.Dto
{
    public class OrganizationUpdateDto : UpdateDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WWW { get; set; }
        public required List<Address> Addresses { get; set; }
        public string? Name { get; set; }
    }
}
