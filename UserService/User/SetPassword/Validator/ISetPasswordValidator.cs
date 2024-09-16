using Core.Base.Validator;
using Model.Edu.User;
using UserService.User.SetPassword.Dto;

namespace UserService.User.SetPassword.Validator
{
    public interface ISetPasswordValidator : IBaseUpdateValidator<UserDbo, SetPasswordDto> { }
}
