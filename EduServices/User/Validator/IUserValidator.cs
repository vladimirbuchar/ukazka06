using Core.Base.Validator;
using Core.DataTypes;
using Model.Edu.User;
using Repository.UserRepository;
using Services.User.Dto;

namespace Services.User.Validator
{
    public interface IUserValidator : IBaseValidator<UserDbo, IUserRepository, UserCreateDto, UserDetailDto, UserUpdateDto>
    {
        Result IsValidSetNewPassword(SetNewPasswordDto setNewPassword);
        Result IsValidActivateUser(ActivateUserDto activateUser);
        Result ChangePasswordValidate(ChangePasswordDto changePassword);
        Result SetPasswordValidate(SetPasswordDto setPasswordDto);
    }
}
