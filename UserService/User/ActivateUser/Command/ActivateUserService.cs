using Core.Base.Command.Update;
using Model.Edu.User;
using Repository.User;
using UserService.User.ActivateUser.Convertor;
using UserService.User.ActivateUser.Dto;
using UserService.User.ActivateUser.Validator;

namespace UserService.User.ActivateUser.Command
{
    public class ActivateUserService(IUserRepository repository, IActivateUserConvertor convertor, IActivateUserValidator validator) : BaseUpdateCommand<UserDbo, IUserRepository, ChangeUserActiveDto, IActivateUserConvertor, IActivateUserValidator>(repository, convertor, validator), IActivateUserService
    {
    }
}
