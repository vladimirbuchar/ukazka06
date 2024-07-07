using Core.Base.Dto;

namespace Services.OrganizationCulture.Dto
{
    public class OrganizationCultureDetailDto : DetailDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
