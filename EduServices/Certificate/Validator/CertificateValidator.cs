using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Certificate;
using Repository.CertificateRepository;
using Repository.OrganizationRepository;
using Services.Certificate.Dto;
using System.Threading.Tasks;

namespace Services.Certificate.Validator
{
    public class CertificateValidator(ICertificateRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<CertificateDbo, ICertificateRepository, CertificateCreateDto, CertificateDetailDto, CertificateUpdateDto>(repository),
            ICertificateValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override async Task<Result> IsValid(CertificateCreateDto create)
        {
            Result<CertificateDetailDto> validate = new();
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            IsValidString(create.Name, validate, MessageCategory.CERTIFICATE, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.CertificateValidTo, validate, MessageCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return validate;
        }

        public override Task<Result<CertificateDetailDto>> IsValid(CertificateUpdateDto update)
        {
            Result<CertificateDetailDto> validate = new();
            IsValidString(update.Name, validate, MessageCategory.CERTIFICATE, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.CertificateValidTo, validate, MessageCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return Task.FromResult(validate);
        }
    }
}
