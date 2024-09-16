using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Convertor;
using OrganizationService.Certificate.CertificateUpdate.Dto;
using OrganizationService.Certificate.CertificateUpdate.Validator;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateUpdate.Command
{
    public class CertificateUpdateService
        : BaseUpdateCommand<CertificateDbo, ICertificateRepository, CertificateUpdateDto, ICertificateUpdateConvertor, ICertificateUpdateValidator>,
            ICertificateUpdateService
    {
        public CertificateUpdateService(
            ICertificateRepository repository,
            ICertificateUpdateConvertor convertor,
            ICertificateUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
