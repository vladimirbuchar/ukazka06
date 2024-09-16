using Core.Base.Validator;
using Model.Edu.User;
using UserService.User.UserUpdate.Dto;

namespace UserService.User.UserUpdate.Validator
{
    public interface IUserUpdateValidator : IBaseUpdateValidator<UserDbo, UserUpdateDto> { }
}
