using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Dto;

namespace OrganizationService.Certificate.CertificateUpdate.Convertor
{
    public class CertificateUpdateConvertor : ICertificateUpdateConvertor
    {
        public Task<CertificateDbo> ConvertToBussinessEntity(CertificateUpdateDto update, CertificateDbo entity, string culture)
        {
            entity.CertificateTranslations = entity.CertificateTranslations.PrepareTranslation(update.Name, update.Html, update.CultureId);
            entity.CertificateValidTo = update.CertificateValidTo;
            return Task.FromResult(entity);
        }
    }
}
