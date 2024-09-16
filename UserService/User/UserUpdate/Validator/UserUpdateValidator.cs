using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.User;
using Repository.User;
using UserService.User.UserUpdate.Dto;

namespace UserService.User.UserUpdate.Validator
{
    public class UserUpdateValidator : BaseUpdateValidator<UserDbo, IUserRepository, UserUpdateDto>, IUserUpdateValidator
    {
        private readonly ICodeBookRepository<CountryDbo> _country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType;

        public UserUpdateValidator(
            IUserRepository repository,
            ICodeBookRepository<CountryDbo> country,
            ICodeBookRepository<AddressTypeDbo> addressType
        )
            : base(repository)
        {
            _country = country;
            _addressType = addressType;
        }

        public override async Task<Result> IsValid(UserUpdateDto update)
        {
            Result validate = new();
            IsValidString(update.Person.FirstName, validate, MessageCategory.USER, Constants.FIRST_NAME_IS_EMPTY);
            IsValidString(update.Person.LastName, validate, MessageCategory.USER, Constants.LAST_NAME_IS_EMPTY);
            await ValidateAddress(update.Person.Address, validate);
            return validate;
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
