using Core.Base.Validator;
using Model.Edu.User;
using UserService.User.RegisterUser.Dto;

namespace UserService.User.RegisterUser.Validator
{
    public interface IRegisterUserValidator : IBaseCreateValidator<UserDbo, UserCreateDto> { }
}
