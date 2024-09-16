using Core.Base.Command.Update;
using Model.Edu.User;
using Repository.User;
using UserService.User.SetPassword.Convertor;
using UserService.User.SetPassword.Dto;
using UserService.User.SetPassword.Validator;

namespace UserService.User.SetPassword.Command
{
    public class SetPasswordService
        : BaseUpdateCommand<UserDbo, IUserRepository, SetPasswordDto, ISetPasswordConvertor, ISetPasswordValidator>,
            ISetPasswordService
    {
        public SetPasswordService(IUserRepository repository, ISetPasswordConvertor convertor, ISetPasswordValidator validator)
            : base(repository, convertor, validator) { }
    }
}
