using Core.Base.Dto;

namespace OrganizationService.Certificate.CertificateList.Dto
{
    public class CertificateListDto : ListDto
    {
        public string? Name { get; set; }
        public int CertificateValidTo { get; set; }
    }
}
