using Core.Base.Convertor;
using Model.Edu.UserRole;
using UserService.Role.RoleDetail.Dto;

namespace UserService.Role.RoleDetail.Convertor
{
    public interface IRoleDetailConvertor : IBaseDetailConvertor<UserRoleDbo, RoleDetailDto>
    {
    }
}