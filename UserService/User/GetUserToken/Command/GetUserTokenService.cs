using Core.Base.Command;
using Core.Constants;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.Edu.User;
using Model.Link;
using Repository.User;
using Repository.UserInOrganization;
using Services.User.Helper;
using UserService.User.GetUserToken.Dto;
using UserService.User.Shared.Convertor;
using UserService.User.Shared.Dto;

namespace UserService.User.GetUserToken.Command
{
    public class GetUserTokenService(
        IConfiguration configuration,
        IUserInOrganizationRepository userInOrganizationRepository,
        IUserRepository userRepository,
        IGetUserTokenConvertor userLoginConvertor
        ) : BaseCommand<IUserRepository>(userRepository), IGetUserTokenService
    {
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly IGetUserTokenConvertor _userLoginConvertor = userLoginConvertor;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string?> Execute(GetUserTokenDto loginData)
        {
            UserDbo loginUser = await _repository.GetEntity(
                false,
                x =>
                    x.UserEmail == loginData.UserEmail
                    && x.UserPassword == loginData.UserPassword.GetHashString()
                    && x.IsActive == true
                    && x.AllowCLassicLogin == true
            );
            if (loginUser != null)
            {
                if (
                    loginData.OrganizationId != null
                    && _userInOrganizationRepository.GetEntity(false, x => x.UserId == loginUser.Id && x.OrganizationId == loginData.OrganizationId)
                        == null
                )
                {
                    return null;
                }

                UserTokenDto user = _userLoginConvertor.ConvertToWebModel(loginUser);
                if (user.UserRole == UserRole.REGISTERED_USER)
                {
                    List<UserInOrganizationDbo> roles = await _userInOrganizationRepository.GetEntities(false, x => x.UserId == loginUser.Id);
                    if (loginData.OrganizationId != null)
                    {
                        roles = roles.Where(x => x.OrganizationId == loginData.OrganizationId).ToList();
                    }
                    foreach (UserInOrganizationDbo role in roles)
                    {
                        if (!user.OrganizationRole.TryGetValue(role.OrganizationId, out List<string>? value))
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

            }
            return null;
        }
    }
}
