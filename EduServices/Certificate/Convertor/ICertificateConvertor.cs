using Core.Base.Convertor;
using EduServices.Certificate.Dto;
using Model.Edu.Certificate;

namespace EduServices.Certificate.Convertor
{
    public interface ICertificateConvertor : IBaseConvertor<CertificateDbo, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto> { }
}
