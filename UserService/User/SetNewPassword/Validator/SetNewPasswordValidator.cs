using Core.Base.Validator;
using Core.DataTypes;
using Services.User.Helper;
using UserService.User.SetNewPassword.Dto;

namespace UserService.User.SetNewPassword.Validator
{
    public class SetNewPasswordValidator : BaseValidator, ISetNewPasswordValidator
    {
        public async Task<Result> IsValidSetNewPassword(SetNewPasswordDto changePassword)
        {
            Result validate = new();
            UserHelper.IsValidPassword(changePassword.Password1, changePassword.Password2, validate);
            return await Task.FromResult(validate);
        }
    }
}
