using Core.Base.Dto;

namespace OrganizationService.Certificate.CertificateUpdate.Dto
{
    public class CertificateUpdateDto : UpdateDto
    {
        public string? Name { get; set; }
        public string? Html { get; set; }
        public int CertificateValidTo { get; set; }
    }
}
