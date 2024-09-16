using Core.Base.Validator;
using Model.Edu.User;
using Repository.User;
using UserService.User.ActivateUser.Dto;

namespace UserService.User.ActivateUser.Validator
{
    public class ActivateUserValidator : BaseUpdateValidator<UserDbo, IUserRepository, ChangeUserActiveDto>, IActivateUserValidator
    {
        public ActivateUserValidator(IUserRepository repository) : base(repository)
        {
        }
    }
}
