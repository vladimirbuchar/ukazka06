using Core.Base.Dto;

namespace Services.Certificate.Dto
{
    public class CertificateListDto : ListDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
    }
}
