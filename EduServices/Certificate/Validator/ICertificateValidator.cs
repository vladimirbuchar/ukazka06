using Core.Base.Validator;
using Model.Edu.Certificate;
using Repository.CertificateRepository;
using Services.Certificate.Dto;

namespace Services.Certificate.Validator
{
    public interface ICertificateValidator
        : IBaseValidator<CertificateDbo, ICertificateRepository, CertificateCreateDto, CertificateDetailDto, CertificateUpdateDto> { }
}
