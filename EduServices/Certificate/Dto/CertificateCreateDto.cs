using Core.Base.Dto;
using System;

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
