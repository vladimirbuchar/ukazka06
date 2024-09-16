using Core.Base.Command;
using Core.Constants;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.Edu.User;
using Repository.User;
using Services.User.Helper;
using UserService.User.GetUserTokenAdmin.Dto;
using UserService.User.Shared.Convertor;
using UserService.User.Shared.Dto;

namespace UserService.User.GetUserTokenAdmin.Command
{
    public class GetUserTokenAdminService(IConfiguration configuration, IGetUserTokenConvertor convertor, IUserRepository userRepository) : BaseCommand<IUserRepository>(userRepository), IGetUserTokenAdminService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IGetUserTokenConvertor _convertor = convertor;

        public async Task<string?> Execute(LoginUserAdminDto loginData)
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
                UserTokenDto user = _convertor.ConvertToWebModel(loginUser);
                return user.UserRole != UserRole.ADMINISTRATOR ? null : UserHelper.GenerateJWTToken(_configuration, user);
            }
            return null;
        }
    }
}
