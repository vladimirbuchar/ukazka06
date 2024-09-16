using Core.Base.Command.Detail;
using Model.Edu.UserRole;
using UserService.Role.RoleDetail.Dto;

namespace UserService.Role.RoleDetail.Command
{
    public interface IRoleDetailService : IBaseDetailCommand<UserRoleDbo, RoleDetailDto>
    {
    }
}