using Model.Edu.User;
using UserService.User.ActivateUser.Dto;

namespace UserService.User.ActivateUser.Convertor
{
    public class ActivateUserConvertor : IActivateUserConvertor
    {
        public Task<UserDbo> ConvertToBussinessEntity(ChangeUserActiveDto update, UserDbo entity, string culture)
        {
            entity.IsActive = update.IsActive;
            return Task.FromResult(entity);
        }
    }
}
