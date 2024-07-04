using Core.Base.Service;
using Core.DataTypes;
using EduServices.User.Dto;
using Model.Tables.Edu.User;
using System;

namespace EduServices.User.Service
{
    public interface IUserService : IBaseService<UserDbo, UserCreateDto, UserListDto, UserDetailDto, UserUpdateDto>
    {
        /// <summary>
        /// return information for user login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserTokenDto LoginUser(LoginUserDto loginData);
        UserTokenDto LoginUser(LoginUserAdminDto loginData);

        /// <summary>
        /// method for change user password
        /// </summary>
        /// <param name="changePassword"></param>
        void ChangePassword(Guid userId, string newPassword);
        Result ActivateUser(ActivateUserDto activateUser);
        Result SetNewPassword(SetNewPasswordDto setNewPasswordDto);
        UserTokenDto LoginSocialNetwork(LoginUserSocialNetworkDto loginSocialNetwork, string culture);
        Result GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto, string clientCulture);
        Result ChangePassword(ChangePasswordDto changePassword);
        string RefreshToken(Guid userId);
        Result SetPassword(SetPasswordDto changePassword);
    }
}
