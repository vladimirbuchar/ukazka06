using Core.Base.Command.Delete;
using Model.Edu.Certificate;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateDelete.Command
{
    public class CertificateDeleteService : BaseDeleteCommand<CertificateDbo, ICertificateRepository>, ICertificateDeleteService
    {
        public CertificateDeleteService(ICertificateRepository repository)
            : base(repository) { }
    }
}
