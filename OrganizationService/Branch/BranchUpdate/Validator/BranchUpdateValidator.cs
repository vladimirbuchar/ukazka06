using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Dto;
using Repository.Branch;

namespace OrganizationService.Branch.BranchUpdate.Validator
{
    public class BranchUpdateValidator : BaseUpdateValidator<BranchDbo, IBranchRepository, BranchUpdateDto>, IBranchUpdateValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country;

        public BranchUpdateValidator(IBranchRepository repository, ICodeBookRepository<CountryDbo> country)
            : base(repository)
        {
            _country = country;
        }

        public override async Task<Result> IsValid(BranchUpdateDto update)
        {
            Result validate = new();
            IsValidEmail(update.Email, validate, MessageCategory.BRANCH, MessageItem.EMAIL_IS_NOT_VALID);
            IsValidUri(update.WWW, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_URI);
            IsValidPhoneNumber(update.PhoneNumber, validate, MessageCategory.BRANCH, MessageItem.IS_NOT_VALID_PHONE_NUMBER);
            IsValidString(update.Name, validate, MessageCategory.BRANCH, MessageItem.STRING_IS_EMPTY);
            if (update.CountryId.HasValue)
            {
                await base.CodeBookValueExist(
                    _country,
                    x => x.Id == update.CountryId,
                    validate,
                    AddressValidator.COUNTRY,
                    AddressValidator.COUNTRY_NOT_EXIST,
                    update.CountryId.ToString()
                );
            }
            return validate;
        }
    }
}
