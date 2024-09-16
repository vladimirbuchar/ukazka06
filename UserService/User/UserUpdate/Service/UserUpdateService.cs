using Core.Base.Command.Update;
using Model.Edu.User;
using Repository.User;
using UserService.User.UserUpdate.Convertor;
using UserService.User.UserUpdate.Dto;
using UserService.User.UserUpdate.Validator;

namespace UserService.User.UserUpdate.Service
{
    public class UserUpdateService
        : BaseUpdateCommand<UserDbo, IUserRepository, UserUpdateDto, IUserUpdateConvertor, IUserUpdateValidator>,
            IUserUpdateService
    {
        public UserUpdateService(IUserRepository repository, IUserUpdateConvertor convertor, IUserUpdateValidator validator)
            : base(repository, convertor, validator) { }
    }
}
