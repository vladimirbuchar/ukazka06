using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Convertor;
using OrganizationService.Certificate.CertificateCreate.Dto;
using OrganizationService.Certificate.CertificateCreate.Validator;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateCreate.Command
{
    public class CertificateCreateService
        : BaseCreateCommand<CertificateDbo, ICertificateRepository, CertificateCreateDto, ICertificateCreateConvertor, ICertificateCreateValidator>,
            ICertificateCreateService
    {
        public CertificateCreateService(
            ICertificateRepository repository,
            ICertificateCreateConvertor convertor,
            ICertificateCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
