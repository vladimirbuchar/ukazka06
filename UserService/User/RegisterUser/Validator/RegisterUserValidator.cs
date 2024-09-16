using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.User;
using Repository.User;
using Services.User.Helper;
using UserService.User.RegisterUser.Dto;

namespace UserService.User.RegisterUser.Validator
{
    public class RegisterUserValidator : BaseCreateValidator<UserDbo, IUserRepository, UserCreateDto>, IRegisterUserValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType;

        public RegisterUserValidator(
            IUserRepository repository,
            ICodeBookRepository<AddressTypeDbo> addressType,
            ICodeBookRepository<CountryDbo> country
        )
            : base(repository)
        {
            _country = country;
            _addressType = addressType;
        }

        public override async Task<ResultInsert> IsValid(UserCreateDto create)
        {
            ResultInsert validate = new();
            await IsValidUserEmail(create.UserEmail, Guid.Empty, validate);
            UserHelper.IsValidPassword(create.UserPassword, create.UserPassword2, validate);
            IsValidString(create.Person.FirstName, validate, MessageCategory.USER, Constants.FIRST_NAME_IS_EMPTY);
            IsValidString(create.Person.LastName, validate, MessageCategory.USER, Constants.LAST_NAME_IS_EMPTY);
            await ValidateAddress(create.Person.Address, validate);
            return validate;
        }

        private async Task IsValidUserEmail(string? email, Guid id, Result result)
        {
            email = email?.Trim();
            IsValidString(email, result, MessageCategory.USER, MessageItem.EMAIL_IS_EMPTY);
            IsValidEmail(email, result, MessageCategory.USER, MessageItem.EMAIL_IS_NOT_VALID);
            if (id == Guid.Empty)
            {
                await IsExist(x => x.UserEmail == email, result, MessageCategory.USER, MessageItem.EMAIL_EXIST, email);
            }
        }

        private async Task ValidateAddress(List<Address> addresses, Result result)
        {
            if (addresses != null && addresses.Count > 0)
            {
                foreach (Address address in addresses)
                {
                    await base.CodeBookValueExist(
                        _country,
                        x => x.Id == address.CountryId,
                        result,
                        AddressValidator.COUNTRY,
                        AddressValidator.COUNTRY_NOT_EXIST,
                        address.CountryId.ToString()
                    );
                    await base.CodeBookValueExist(
                        _addressType,
                        x => x.Id == address.AddressTypeId,
                        result,
                        AddressValidator.ADDRESS_TYPE,
                        AddressValidator.ADDRESS_TYPE_NOT_EXIST,
                        address.AddressTypeId.ToString()
                    );
                }
            }
        }
    }
}
