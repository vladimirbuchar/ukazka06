using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.BranchRepository;
using EduRepository.OrganizationRepository;
using EduServices.Branch.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Branch;

namespace EduServices.Branch.Validator
{
    public class BranchValidator(IBranchRepository repository, IOrganizationRepository organizationRepository, ICodeBookRepository<CountryDbo> country)
        : BaseValidator<BranchDbo, IBranchRepository, BranchCreateDto, BranchDetailDto, BranchUpdateDto>(repository),
            IBranchValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country = country;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<BranchDetailDto> IsValid(BranchCreateDto create)
        {
            Result<BranchDetailDto> validate = new();
            IsValidEmail(create.Email, validate, ErrorCategory.BRANCH, GlobalValue.EMAIL_IS_NOT_VALID);
            IsValidUri(create.WWW, validate, ErrorCategory.BRANCH, GlobalValue.IS_NOT_VALID_URI);
            IsValidPhoneNumber(create.PhoneNumber, validate, ErrorCategory.BRANCH, GlobalValue.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(create.Name, validate, ErrorCategory.BRANCH, GlobalValue.STRING_IS_EMPTY);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            if (create.CountryId.HasValue)
            {
                base.CodeBookValueExist(_country, x => x.Id == create.CountryId, validate, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, create.CountryId.ToString());
            }

            return validate;
        }

        public override Result<BranchDetailDto> IsValid(BranchUpdateDto update)
        {
            Result<BranchDetailDto> validate = new();
            IsValidEmail(update.Email, validate, ErrorCategory.BRANCH, GlobalValue.EMAIL_IS_NOT_VALID);
            IsValidUri(update.WWW, validate, ErrorCategory.BRANCH, GlobalValue.IS_NOT_VALID_URI);
            IsValidPhoneNumber(update.PhoneNumber, validate, ErrorCategory.BRANCH, GlobalValue.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(update.Name, validate, ErrorCategory.BRANCH, GlobalValue.STRING_IS_EMPTY);
            if (update.CountryId.HasValue)
            {
                base.CodeBookValueExist(_country, x => x.Id == update.CountryId, validate, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, update.CountryId.ToString());
            }

            return validate;
        }
    }
}
