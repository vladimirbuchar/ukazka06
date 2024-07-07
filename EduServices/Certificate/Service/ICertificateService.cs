using Core.Base.Service;
using Model.Edu.Certificate;
using Services.Certificate.Dto;

namespace Services.Certificate.Service
{
    public interface ICertificateService : IBaseService<CertificateDbo, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto> { }
}
