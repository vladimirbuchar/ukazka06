using Core.Base.Filter;

namespace OrganizationService.OrganizationCulture.OrganizationCultureList.Filter
{
    public class OrganizationCultureFilter : RequestFilter
    {
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
    }
}
