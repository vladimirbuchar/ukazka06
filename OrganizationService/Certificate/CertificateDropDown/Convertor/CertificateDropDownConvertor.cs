using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDropDown.Dto;

namespace OrganizationService.Certificate.CertificateDropDown.Convertor
{
    public class CertificateDropDownConvertor : ICertificateDropDownConvertor
    {
        public Task<List<CertificateDropDownDto>> ConvertToWebModel(List<CertificateDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new CertificateDropDownDto()
            {
                Name = x.CertificateTranslations.FindTranslation(culture).Name,
                Id = x.Id,
            }).ToList());
        }
    }
}
