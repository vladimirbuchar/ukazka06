using Core.Base.Convertor;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Dto;

namespace OrganizationService.Certificate.CertificateUpdate.Convertor
{
    public interface ICertificateUpdateConvertor : IBaseUpdateConvertor<CertificateDbo, CertificateUpdateDto> { }
}
