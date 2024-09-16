using Core.Base.Command.Restore;
using Model.Edu.Certificate;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateRestore.Command
{
    public class CertificateRestoreService : BaseRestoreCommand<CertificateDbo, ICertificateRepository>, ICertificateRestoreService
    {
        public CertificateRestoreService(ICertificateRepository repository)
            : base(repository) { }
    }
}
