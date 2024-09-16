using Core.Base.Command.Update;
using Model.Edu.User;
using Repository.User;
using UserService.User.ChangePassword.Convertor;
using UserService.User.ChangePassword.Dto;
using UserService.User.ChangePassword.Validator;

namespace UserService.User.ChangePassword.Command
{
    public class ChangePasswordService
        : BaseUpdateCommand<UserDbo, IUserRepository, ChangePasswordDto, IChangePasswordConvertor, IChangePasswordValidator>,
            IChangePasswordService
    {
        public ChangePasswordService(IUserRepository repository, IChangePasswordValidator validator, IChangePasswordConvertor convertor)
            : base(repository, convertor, validator) { }
    }
}
