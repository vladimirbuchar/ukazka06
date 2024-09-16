using Core.Base.Convertor;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDetail.Dto;

namespace OrganizationService.Certificate.CertificateDetail.Convertor
{
    public interface ICertificateDetailConvertor : IBaseDetailConvertor<CertificateDbo, CertificateDetailDto> { }
}
