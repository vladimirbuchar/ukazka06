using Core.Base.Request;

namespace Services.OrganizationCulture.Filter
{
    public class OrganizationCultureFilter : FilterRequest
    {
        public string Name { get; set; }
        public bool? IsDefault { get; set; }
    }
}
