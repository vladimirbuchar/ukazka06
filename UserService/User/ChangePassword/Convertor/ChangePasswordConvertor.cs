using Core.Extension;
using Model.Edu.User;
using UserService.User.ChangePassword.Dto;

namespace UserService.User.ChangePassword.Convertor
{
    public class ChangePasswordConvertor : IChangePasswordConvertor
    {
        public Task<UserDbo> ConvertToBussinessEntity(ChangePasswordDto update, UserDbo entity, string culture)
        {
            entity.UserPassword = update.NewUserPassword.GetHashString();
            return Task.FromResult(entity);
        }
    }
}
