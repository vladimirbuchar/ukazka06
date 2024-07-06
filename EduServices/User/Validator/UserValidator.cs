using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.LinkLifeTimeRepository;
using EduRepository.UserRepository;
using EduServices.User.Dto;
using Model.CodeBook;
using Model.Edu.LinkLifeTime;
using Model.Edu.User;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EduServices.User.Validator
{
    public partial class UserValidator(
        ICodeBookRepository<AddressTypeDbo> addressType,
        IUserRepository repository,
        ICodeBookRepository<CountryDbo> country,
        ILinkLifeTimeRepository linkLifeTimeRepository
    ) : BaseValidator<UserDbo, IUserRepository, UserCreateDto, UserDetailDto, UserUpdateDto>(repository), IUserValidator
    {
        private readonly ILinkLifeTimeRepository _linkLifeTimeRepository = linkLifeTimeRepository;
        private readonly ICodeBookRepository<CountryDbo> _country = country;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressType = addressType;

        public override Result<UserDetailDto> IsValid(UserCreateDto create)
        {
            Result<UserDetailDto> validate = new();
            IsValidUserEmail(create.UserEmail, Guid.Empty, validate);
            IsValidPassword(create.UserPassword, create.UserPassword2, validate);
            IsValidString(create.Person.FirstName, validate, Category.USER, Constants.FIRST_NAME_IS_EMPTY);
            IsValidString(create.Person.LastName, validate, Category.USER, Constants.LAST_NAME_IS_EMPTY);
            ValidateAddress(create.Person.Address, validate);
            return validate;
        }

        private void ValidateAddress(HashSet<Address> addresses, Result result)
        {
            if (addresses != null && addresses.Count > 0)
            {
                foreach (Address address in addresses)
                {
                    base.CodeBookValueExist(_country, x => x.Id == address.CountryId, result, AddressValidator.COUNTRY, AddressValidator.COUNTRY_NOT_EXIST, address.CountryId.ToString());
                    base.CodeBookValueExist(
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

        private void IsValidUserEmail(string email, Guid id, Result result)
        {
            email = email?.Trim();
            IsValidString(email, result, Category.USER, GlobalValue.EMAIL_IS_EMPTY);
            IsValidEmail(email, result, Category.USER, GlobalValue.EMAIL_IS_NOT_VALID);
            if (id == Guid.Empty)
            {
                IsExist(x => x.UserEmail == email, result, Category.USER, GlobalValue.EMAIL_EXIST, email);
            }
        }

        private static void IsValidPassword(string password1, string password2, Result result)
        {
            password1 = password1?.Trim();
            password2 = password2?.Trim();
            Regex hasNumber = NumberRegex();
            Regex hasUpperChar = UpperCharRegex();
            Regex hasMinChars = MinCharRegex();
            Regex hasLowerChar = LowerCharRegex();
            Regex hasSymbols = SymbolRegex();
            if (password2.IsNullOrEmptyWithTrim() || password1.IsNullOrEmptyWithTrim())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, GlobalValue.STRING_IS_EMPTY));
            }
            if (password1 != password2)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_ARE_DIFFERENT));
            }
            if (!hasLowerChar.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_NOT_LOWER_CHAR));
            }
            if (!hasUpperChar.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_NOT_UPPER_CHAR));
            }
            if (!hasMinChars.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_NOT_MIN_LENGTH));
            }
            if (!hasNumber.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_NOT_NUMBER));
            }
            if (!hasSymbols.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.PASSWORD_NOT_SYMBOLS));
            }
        }

        public Result IsValidSetNewPassword(SetNewPasswordDto validate)
        {
            Result result = new();
            IsValidPassword(validate.Password1, validate.Password2, result);
            LinkLifeTimeDbo linkLifeTime = _linkLifeTimeRepository.GetEntity(false, x => x.Id == validate.LinkId && x.EndTime >= DateTime.Now);
            if (linkLifeTime == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.LINK_IS_NOT_VALID));
            }

            return result;
        }

        public Result IsValidActivateUser(ActivateUserDto validate)
        {
            Result result = new();
            LinkLifeTimeDbo linkLifeTime = _linkLifeTimeRepository.GetEntity(false, x => x.Id == validate.LinkId && x.EndTime >= DateTime.Now);
            if (linkLifeTime == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.LINK_IS_NOT_VALID));
            }

            return result;
        }

        public void IsValidOldPassword(Guid userId, string oldPassword, Result result)
        {
            UserDbo user = _repository.GetEntity(userId);
            if (user.UserPassword != oldPassword.GetHashString())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.USER, Constants.OLD_PASSWORD_IS_BAD));
            }
        }

        public Result ChangePasswordValidate(ChangePasswordDto changePassword)
        {
            Result validate = new();
            IsValidOldPassword(changePassword.UserId, changePassword.OldUserPassword, validate);
            IsValidPassword(changePassword.NewUserPassword, changePassword.NewUserPassword2, validate);
            return validate;
        }

        public Result SetPasswordValidate(SetPasswordDto changePassword)
        {
            Result validate = new();
            IsValidPassword(changePassword.NewUserPassword, changePassword.NewUserPassword2, validate);
            return validate;
        }


        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex NumberRegex();

        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UpperCharRegex();

        [GeneratedRegex(@".{8}")]
        private static partial Regex MinCharRegex();

        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowerCharRegex();

        [GeneratedRegex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]")]
        private static partial Regex SymbolRegex();
    }
}
