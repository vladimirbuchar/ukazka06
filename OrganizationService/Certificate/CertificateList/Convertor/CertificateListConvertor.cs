using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateList.Dto;

namespace OrganizationService.Certificate.CertificateList.Convertor
{
    public class CertificateListConvertor : ICertificateListConvertor
    {
        public Task<List<CertificateListDto>> ConvertToWebModel(List<CertificateDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CertificateListDto()
                {
                    Id = item.Id,
                    Name = item.CertificateTranslations.FindTranslation(culture).Name,
                    CertificateValidTo = item.CertificateValidTo
                })
                    .ToList()
            );
        }
    }
}
