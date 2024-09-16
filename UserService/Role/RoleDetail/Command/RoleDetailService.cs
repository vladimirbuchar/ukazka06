using Core.Base.Command.Detail;
using Model.Edu.UserRole;
using Repository.Role;
using UserService.Role.RoleDetail.Convertor;
using UserService.Role.RoleDetail.Dto;

namespace UserService.Role.RoleDetail.Command
{
    public class RoleDetailService : BaseDetailCommand<UserRoleDbo, IRoleRepository, RoleDetailDto, IRoleDetailConvertor>, IRoleDetailService
    {
        public RoleDetailService(IRoleRepository repository, IRoleDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
