using Core.Base.Request;

namespace Services.Certificate.Filter
{
    public class CertificateFilter : FilterRequest
    {
        public string Name { get; set; }
        public int? CertificateValidTo { get; set; }
    }
}
