using Core.Base.Validator;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Dto;

namespace OrganizationService.Certificate.CertificateCreate.Validator
{
    public interface ICertificateCreateValidator : IBaseCreateValidator<CertificateDbo, CertificateCreateDto> { }
}
