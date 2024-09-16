using Core.Base.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureList.Dto
{
    public class OrganizationCultureListDto : ListDto
    {
        public string? Name { get; set; }
        public bool IsDefault { get; set; }
        public Guid CultureId { get; set; }
    }
}
