using UserService.User.GetUserTokenAdmin.Dto;

namespace UserService.User.GetUserTokenAdmin.Command
{
    public interface IGetUserTokenAdminService
    {
        Task<string> Execute(LoginUserAdminDto loginData);
    }
}
