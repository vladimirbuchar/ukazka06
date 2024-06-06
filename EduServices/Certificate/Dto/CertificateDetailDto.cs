using Core.Base.Dto;

namespace EduServices.Certificate.Dto
{
    public class CertificateDetailDto : DetailDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public int CertificateValidTo { get; set; }
    }
}
