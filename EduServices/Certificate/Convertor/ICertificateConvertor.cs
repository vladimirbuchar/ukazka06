using Core.Base.Convertor;
using Model.Edu.Certificate;
using Services.Certificate.Dto;

namespace Services.Certificate.Convertor
{
    public interface ICertificateConvertor
        : IBaseConvertor<CertificateDbo, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto> { }
}
