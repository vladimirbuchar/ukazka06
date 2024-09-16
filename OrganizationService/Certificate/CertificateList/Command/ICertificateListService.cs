using Core.Base.Command.List;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateList.Dto;
using OrganizationService.Certificate.CertificateList.Filter;

namespace OrganizationService.Certificate.CertificateList.Command
{
    public interface ICertificateListService : IBaseListCommand<CertificateDbo, CertificateListDto, CertificateFilter> { }
}
