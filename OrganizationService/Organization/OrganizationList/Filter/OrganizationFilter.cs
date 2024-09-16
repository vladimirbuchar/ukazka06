using Core.Base.Filter;

namespace OrganizationService.Organization.OrganizationList.Filter
{
    public class OrganizationFilter : RequestFilter
    {
        public string? Name { get; set; }
    }
}
