using Core.Base.Command.Create;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Dto;

namespace OrganizationService.Certificate.CertificateCreate.Command
{
    public interface ICertificateCreateService : IBaseCreateCommand<CertificateDbo, CertificateCreateDto> { }
}
