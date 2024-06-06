using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CertificateRepository;
using EduRepository.OrganizationRepository;
using EduServices.Certificate.Dto;
using Model.Tables.Edu.Certificate;

namespace EduServices.Certificate.Validator
{
    public class CertificateValidator(ICertificateRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<CertificateDbo, ICertificateRepository, CertificateCreateDto, CertificateDetailDto, CertificateUpdateDto>(repository),
            ICertificateValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<CertificateDetailDto> IsValid(CertificateCreateDto create)
        {
            Result<CertificateDetailDto> validate = new();
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            IsValidString(create.Name, validate, ErrorCategory.CERTIFICATE, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.CertificateValidTo, validate, ErrorCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return validate;
        }

        public override Result<CertificateDetailDto> IsValid(CertificateUpdateDto update)
        {
            Result<CertificateDetailDto> validate = new();
            IsValidString(update.Name, validate, ErrorCategory.CERTIFICATE, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.CertificateValidTo, validate, ErrorCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return validate;
        }
    }
}
