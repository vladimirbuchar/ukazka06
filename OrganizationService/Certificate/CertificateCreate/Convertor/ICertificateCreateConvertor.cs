using Core.Base.Convertor;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Dto;

namespace OrganizationService.Certificate.CertificateCreate.Convertor
{
    public interface ICertificateCreateConvertor : IBaseCreateConvertor<CertificateDbo, CertificateCreateDto> { }
}
