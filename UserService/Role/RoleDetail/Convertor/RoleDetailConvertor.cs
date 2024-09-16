using Model.Edu.UserRole;
using UserService.Role.RoleDetail.Dto;

namespace UserService.Role.RoleDetail.Convertor
{
    public class RoleDetailConvertor : IRoleDetailConvertor
    {
        public Task<RoleDetailDto> ConvertToWebModel(UserRoleDbo detail, List<string> culture)
        {
            return Task.FromResult(new RoleDetailDto()
            {
                Id = detail.Id,
            });
        }
    }
}
