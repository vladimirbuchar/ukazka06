using System;
using Core.Base.Dto;

namespace Services.Certificate.Dto
{
    public class CertificateCreateDto : CreateDto
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public int CertificateValidTo { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
