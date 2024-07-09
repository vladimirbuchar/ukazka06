using Core.Base.Service;
using Model.Edu.Certificate;
using Services.Certificate.Dto;
using Services.Certificate.Filter;

namespace Services.Certificate.Service
{
    public interface ICertificateService
        : IBaseService<CertificateDbo, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto, CertificateFilter> { }
}
