using Core.Base.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto
{
    public class OrganizationCultureCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public new Guid CultureId { get; set; }
        public bool IsDefault { get; set; }
    }
}
