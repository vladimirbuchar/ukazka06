using Core.Base.Command.Create;
using Model.Edu.User;
using Repository.User;
using UserService.User.RegisterUser.Convertor;
using UserService.User.RegisterUser.Dto;
using UserService.User.RegisterUser.Validator;

namespace UserService.User.RegisterUser.Command
{
    public class RegisterUserService
        : BaseCreateCommand<UserDbo, IUserRepository, UserCreateDto, IRegisterUserConvertor, IRegisterUserValidator>,
            IRegisterUserService
    {

        public RegisterUserService(
            IUserRepository repository,
            IRegisterUserConvertor convertor,
            IRegisterUserValidator validator
        )
            : base(repository, convertor, validator)
        {

        }
    }
}
