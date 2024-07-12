using Core.Base.Filter;

namespace Services.Organization.Filter
{
    public class OrganizationFilter : FilterRequest
    {
        public string Name { get; set; }
    }
}
