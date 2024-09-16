using Core.Base.Command.Detail;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDetail.Convertor;
using OrganizationService.Certificate.CertificateDetail.Dto;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateDetail.Command
{
    public class CertificateDetailService
        : BaseDetailCommand<CertificateDbo, ICertificateRepository, CertificateDetailDto, ICertificateDetailConvertor>,
            ICertificateDetailService
    {
        public CertificateDetailService(ICertificateRepository repository, ICertificateDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
