using Core.Base.Validator;
using Model.Edu.User;
using UserService.User.ActivateUser.Dto;

namespace UserService.User.ActivateUser.Validator
{
    public interface IActivateUserValidator : IBaseUpdateValidator<UserDbo, ChangeUserActiveDto>
    {
    }
}
