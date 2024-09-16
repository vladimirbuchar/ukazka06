using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateCreate.Dto;
using Repository.Certificate;
using Repository.Organization;

namespace OrganizationService.Certificate.CertificateCreate.Validator
{
    public class CertificateCreateValidator
        : BaseCreateValidator<CertificateDbo, ICertificateRepository, CertificateCreateDto>,
            ICertificateCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CertificateCreateValidator(ICertificateRepository repository, IOrganizationRepository organizationRepository)
            : base(repository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<ResultInsert> IsValid(CertificateCreateDto create)
        {
            ResultInsert validate = new();
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            IsValidString(create.Name, validate, MessageCategory.CERTIFICATE, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.CertificateValidTo, validate, MessageCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return validate;
        }
    }
}
