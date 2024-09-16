using Core.Base.Command;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.Edu.Person;
using Model.Edu.User;
using Repository.User;

namespace SetupService.CreateAdministratorUser.Command
{
    public class CreateAdministratorUserService : BaseCommand<IUserRepository>, ICreateAdministratorUserService
    {
        private readonly IConfiguration _configuration;
        public CreateAdministratorUserService(IUserRepository repository, IConfiguration configuration) : base(repository)
        {
            _configuration = configuration;
        }

        public async Task<Result> Execute(Guid roleId)
        {
            UserDbo admin = await _repository.GetEntity(
               false,
               x => x.UserEmail == _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value
           );
            if (admin == null)
            {
                _ = await _repository.CreateEntity(
                    new UserDbo()
                    {
                        UserEmail = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_NAME).Value,
                        UserPassword = _configuration.GetSection(ConfigValue.SETUP).GetSection(ConfigValue.USER_PASSWORD).Value.GetHashString(),
                        Person = new PersonDbo() { },
                        UserRoleId = roleId,
                        IsActive = true
                    },
                    Guid.Empty
                );
            }
            return new Result();
        }
    }
}
