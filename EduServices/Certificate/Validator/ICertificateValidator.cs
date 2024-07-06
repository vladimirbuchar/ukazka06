using Core.Base.Validator;
using EduRepository.CertificateRepository;
using EduServices.Certificate.Dto;
using Model.Edu.Certificate;

namespace EduServices.Certificate.Validator
{
    public interface ICertificateValidator : IBaseValidator<CertificateDbo, ICertificateRepository, CertificateCreateDto, CertificateDetailDto, CertificateUpdateDto> { }
}
