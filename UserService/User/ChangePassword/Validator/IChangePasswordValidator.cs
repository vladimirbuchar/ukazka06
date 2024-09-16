using Core.Base.Validator;
using Model.Edu.User;
using UserService.User.ChangePassword.Dto;

namespace UserService.User.ChangePassword.Validator
{
    public interface IChangePasswordValidator : IBaseUpdateValidator<UserDbo, ChangePasswordDto> { }
}
