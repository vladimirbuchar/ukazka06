using Core.Base.Command.Update;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Dto;

namespace OrganizationService.Certificate.CertificateUpdate.Command
{
    public interface ICertificateUpdateService : IBaseUpdateCommand<CertificateDbo, CertificateUpdateDto> { }
}
