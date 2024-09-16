using Core.Base.Filter;

namespace OrganizationService.Certificate.CertificateList.Filter
{
    public class CertificateFilter : RequestFilter
    {
        public string? Name { get; set; }
        public int? CertificateValidTo { get; set; }
    }
}
