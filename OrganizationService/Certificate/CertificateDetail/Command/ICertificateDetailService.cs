using Core.Base.Command.Detail;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDetail.Dto;

namespace OrganizationService.Certificate.CertificateDetail.Command
{
    public interface ICertificateDetailService : IBaseDetailCommand<CertificateDbo, CertificateDetailDto> { }
}
