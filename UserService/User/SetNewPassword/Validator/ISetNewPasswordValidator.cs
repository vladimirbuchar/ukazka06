using Core.DataTypes;
using UserService.User.SetNewPassword.Dto;

namespace UserService.User.SetNewPassword.Validator
{
    public interface ISetNewPasswordValidator
    {
        Task<Result> IsValidSetNewPassword(SetNewPasswordDto setPasswordDto);
    }
}
