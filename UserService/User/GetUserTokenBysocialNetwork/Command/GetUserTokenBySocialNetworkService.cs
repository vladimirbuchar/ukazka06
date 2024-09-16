using Core.Base.Command;
using Core.Constants;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.Edu.User;
using Model.Link;
using Repository.User;
using Services.User.Helper;
using UserService.User.GetUserTokenBysocialNetwork.Dto;
using UserService.User.Shared.Convertor;
using UserService.User.Shared.Dto;

namespace UserService.User.GetUserTokenBysocialNetwork.Command
{
    public class GetUserTokenBySocialNetworkService(
        IGetUserTokenConvertor convertor,
        IConfiguration configuration,
        IUserRepository userRepository
        ) : BaseCommand<IUserRepository>(userRepository), IGetUserTokenBysocialNetworkService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IGetUserTokenConvertor _convertor = convertor;

        public async Task<string?> Execute(LoginUserSocialNetworkDto loginSocialNetwork, string culture)
        {
            if (loginSocialNetwork.UserEmail.IsNullOrEmptyWithTrim() || loginSocialNetwork.Id.IsNullOrEmptyWithTrim())
            {
                return null;
            }
            UserDbo detail = await _repository.GetEntity(false, x => x.UserEmail == loginSocialNetwork.UserEmail);
            UserDbo loginUser = new();
            if (detail == null)
            {
                string password = string.Format("{0}#{1}#{2}", loginSocialNetwork.Id, loginSocialNetwork.Type, loginSocialNetwork.UserEmail);
                _ = _repository.CreateEntity(
                    new UserDbo()
                    {
                        UserEmail = loginSocialNetwork.UserEmail,
                        UserPassword = password,
                        Person = new Model.Edu.Person.PersonDbo()
                        {
                            FirstName = loginSocialNetwork.FirstName,
                            LastName = loginSocialNetwork.LastName.Trim().Trim(',').Trim(),
                            SecondName = "",
                            AvatarUrl = loginSocialNetwork.Avatar,
                        },
                        AllowCLassicLogin = false,
                    },
                    Guid.Empty
                );
                detail = await _repository.GetEntity(false, x => x.UserEmail == loginSocialNetwork.UserEmail);
            }
            if (loginSocialNetwork.OrganizationId != null)
            {
                if (
                     detail.UserInOrganizations.FirstOrDefault(x => x.UserId == detail.Id && x.OrganizationId == loginSocialNetwork.OrganizationId && x.IsDeleted == false) == null
                )
                {
                    return null;
                }
            }
            if (loginSocialNetwork.Type == Constants.GOOGLE)
            {
                loginUser = await _repository.GetEntity(false, x => x.Id == detail.Id);
                loginUser.GoogleId = loginSocialNetwork.Id;
                loginUser.Person.AvatarUrl = loginSocialNetwork.Avatar;
                _ = await _repository.UpdateEntity(loginUser, Guid.Empty);
                loginUser = await _repository.GetEntity(false, x => x.Id == detail.Id && x.GoogleId == loginSocialNetwork.Id);
            }
            if (loginSocialNetwork.Type == Constants.FACEBOOK)
            {
                loginUser = await _repository.GetEntity(false, x => x.Id == detail.Id);
                loginUser.FacebookId = loginSocialNetwork.Id;
                loginUser.Person.AvatarUrl = loginSocialNetwork.Avatar;
                _ = await _repository.UpdateEntity(loginUser, Guid.Empty);
                loginUser = await _repository.GetEntity(false, x => x.Id == detail.Id && x.FacebookId == loginSocialNetwork.Id);
            }
            UserTokenDto user = _convertor.ConvertToWebModel(loginUser);
            if (user.UserRole == UserRole.REGISTERED_USER)
            {
                List<UserInOrganizationDbo> roles = loginUser.UserInOrganizations.Where(x => x.IsDeleted == false && x.UserId == loginUser.Id).ToList();

                if (loginSocialNetwork.OrganizationId != null)
                {
                    roles = roles.Where(x => x.OrganizationId == loginSocialNetwork.OrganizationId).ToList();
                }
                foreach (UserInOrganizationDbo role in roles)
                {
                    if (!user.OrganizationRole.TryGetValue(role.OrganizationId, out List<string> value))
                    {
                        user.OrganizationRole.Add(role.OrganizationId, [role.OrganizationRole.SystemIdentificator]);
                    }
                    else
                    {
                        value.Add(role.OrganizationRole.SystemIdentificator);
                    }
                }
                return UserHelper.GenerateJWTToken(_configuration, user);
            }
            return null;

        }
    }
}
