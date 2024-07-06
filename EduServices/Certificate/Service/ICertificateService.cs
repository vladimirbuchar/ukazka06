using Core.Base.Service;
using EduServices.Certificate.Dto;
using Model.Edu.Certificate;

namespace EduServices.Certificate.Service
{
    public interface ICertificateService : IBaseService<CertificateDbo, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto> { }
}
