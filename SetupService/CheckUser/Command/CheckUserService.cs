using Core.Base.Command;
using Core.Constants;
using Core.Extension;
using Model.Edu.User;
using Repository.User;
using SetupService.CheckUser.Dto;

namespace SetupService.CheckUser.Command
{
    public class CheckUserService : BaseCommand<IUserRepository>, ICheckUserService
    {
        public CheckUserService(IUserRepository repository) : base(repository)
        {
        }

        public async Task<bool> Execute(SetupLoginDto setupLogin)
        {
            UserDbo user = await _repository.GetEntity(
                   false,
                   x =>
                       x.UserEmail == setupLogin.UserEmail
                       && x.UserPassword == setupLogin.Password.GetHashString()
                       && x.IsActive == true
                       && x.AllowCLassicLogin == true
               );
            return user?.UserRole?.SystemIdentificator == UserRole.ADMINISTRATOR;
        }
    }
}
