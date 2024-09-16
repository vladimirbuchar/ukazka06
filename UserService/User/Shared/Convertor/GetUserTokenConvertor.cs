using Core.Extension;
using Model.Edu.User;
using UserService.User.Shared.Dto;

namespace UserService.User.Shared.Convertor
{
    public class GetUserTokenConvertor : IGetUserTokenConvertor
    {
        public UserTokenDto ConvertToWebModel(UserDbo loginUser)
        {
            return new UserTokenDto()
            {
                Id = loginUser.Id,
                IsAvatarUrl = loginUser.Person.AvatarUrl?.IsValidUri(),
                Avatar =
                    loginUser.Person.AvatarUrl == null
                        ? string.Format("{0}{1}", loginUser.Person.FirstName?.FirstOrDefault(), loginUser.Person.LastName?.FirstOrDefault())
                        : loginUser.Person.AvatarUrl.IsValidUri()
                            ? loginUser.Person.AvatarUrl
                            : string.Format("{0}{1}", loginUser.Person.FirstName.FirstOrDefault(), loginUser.Person.LastName.FirstOrDefault()),
                FullName = string.Format("{0} {1}", loginUser.Person.FirstName, loginUser.Person.LastName),
                UserMustChangePassword = loginUser.UserMustChangePassword,
                UserEmail = loginUser.UserEmail,
                UserRole = loginUser.UserRole.SystemIdentificator
            };
        }
    }
}
