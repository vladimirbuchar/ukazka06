using Core.Extension;
using Model.Edu.User;
using UserService.User.SetPassword.Dto;

namespace UserService.User.SetPassword.Convertor
{
    public class SetPasswordConvertor : ISetPasswordConvertor
    {
        public Task<UserDbo> ConvertToBussinessEntity(SetPasswordDto update, UserDbo entity, string culture)
        {
            entity.UserPassword = update.NewUserPassword.GetHashString();
            entity.AllowCLassicLogin = true;
            return Task.FromResult(entity);
        }
    }
}
