using Core.Base.Command;
using Microsoft.Extensions.Configuration;
using Repository.User;
using Services.User.Helper;
using UserService.User.Shared.Convertor;

namespace UserService.User.RefreshToken.Command
{
    public class RefreshTokenService : BaseCommand<IUserRepository>, IRefreshTokenService
    {
        private readonly IGetUserTokenConvertor _convertor;
        private readonly IConfiguration _configuration;

        public RefreshTokenService(IConfiguration configuration, IUserRepository userRespository, IGetUserTokenConvertor convertor)
            : base(userRespository)
        {
            _convertor = convertor;
            _configuration = configuration;
        }

        public async Task<string> Execute(Guid userId)
        {
            return UserHelper.GenerateJWTToken(_configuration, _convertor.ConvertToWebModel(await _repository.GetEntity(userId)));
        }
    }
}
