using Core.Base.Command.Detail;
using Model.Edu.User;
using Repository.User;
using UserService.User.UserDetail.Convertor;
using UserService.User.UserDetail.Dto;

namespace UserService.User.UserDetail.Command
{
    public class UserDetailService : BaseDetailCommand<UserDbo, IUserRepository, UserDetailDto, IUserDetailConvertor>, IUserDetailService
    {
        public UserDetailService(IUserRepository repository, IUserDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
