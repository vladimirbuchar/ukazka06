using Core.Base.Validator;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Dto;

namespace OrganizationService.Certificate.CertificateUpdate.Validator
{
    public interface ICertificateUpdateValidator : IBaseUpdateValidator<CertificateDbo, CertificateUpdateDto> { }
}
