using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Dto;

namespace OrganizationService.Certificate.CertificateCreate.Convertor
{
    public class CertificateCreateConvertor : ICertificateCreateConvertor
    {
        public Task<CertificateDbo> ConvertToBussinessEntity(CertificateCreateDto create, string culture)
        {
            CertificateDbo certificate = new() { OrganizationId = create.OrganizationId, CertificateValidTo = create.CertificateValidTo };
            certificate.CertificateTranslations = certificate.CertificateTranslations.PrepareTranslation(create.Name, create.Html, create.CultureId);
            return Task.FromResult(certificate);
        }
    }
}
