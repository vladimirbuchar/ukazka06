using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDetail.Dto;

namespace OrganizationService.Certificate.CertificateDetail.Convertor
{
    public class CertificateDetailConvertor : ICertificateDetailConvertor
    {
        public Task<CertificateDetailDto> ConvertToWebModel(CertificateDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CertificateDetailDto()
                {
                    Html = detail.CertificateTranslations.FindTranslation(culture).Html,
                    Id = detail.Id,
                    Name = detail.CertificateTranslations.FindTranslation(culture).Name,
                    CertificateValidTo = detail.CertificateValidTo
                }
            );
        }
    }
}
