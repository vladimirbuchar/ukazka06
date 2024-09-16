using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateUpdate.Dto;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateUpdate.Validator
{
    public class CertificateUpdateValidator
        : BaseUpdateValidator<CertificateDbo, ICertificateRepository, CertificateUpdateDto>,
            ICertificateUpdateValidator
    {
        public CertificateUpdateValidator(ICertificateRepository repository)
            : base(repository) { }

        public override Task<Result> IsValid(CertificateUpdateDto update)
        {
            Result validate = new();
            IsValidString(update.Name, validate, MessageCategory.CERTIFICATE, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.CertificateValidTo, validate, MessageCategory.CERTIFICATE, Constants.CERTIFICATE_VALID_TO_IS_NOT_VALID);
            return Task.FromResult(validate);
        }
    }
}
