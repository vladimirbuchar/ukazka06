using Core.Base.Validator;
using Core.DataTypes;
using EduRepository.UserRepository;
using EduServices.User.Dto;
using Model.Tables.Edu.User;

namespace EduServices.User.Validator
{
    public interface IUserValidator : IBaseValidator<UserDbo, IUserRepository, UserCreateDto, UserDetailDto, UserUpdateDto>
    {
        Result IsValidSetNewPassword(SetNewPasswordDto setNewPassword);
        Result IsValidActivateUser(ActivateUserDto activateUser);
        Result ChangePasswordValidate(ChangePasswordDto changePassword);
        Result SetPasswordValidate(SetPasswordDto setPasswordDto);
    }
}
