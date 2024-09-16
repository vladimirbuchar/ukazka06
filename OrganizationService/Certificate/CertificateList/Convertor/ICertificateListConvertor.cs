using Core.Base.Convertor;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateList.Dto;

namespace OrganizationService.Certificate.CertificateList.Convertor
{
    public interface ICertificateListConvertor : IBaseListConvertor<CertificateDbo, CertificateListDto> { }
}
