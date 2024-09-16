using Core.Base.Dto;

namespace OrganizationService.Certificate.CertificateCreate.Dto
{
    public class CertificateCreateDto : CreateDto
    {
        public string? Name { get; set; }
        public string? Html { get; set; }
        public int CertificateValidTo { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
