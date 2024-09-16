using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleList.Dto;

namespace OrganizationService.OrganizationRole.OrganizationRoleList.Convertor
{
    public class OrganizationRoleListConvertor : IOrganizationRoleListConvertor
    {
        public Task<List<OrganizationRoleListDto>> ConvertToWebModel(List<OrganizationRoleDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new OrganizationRoleListDto() { RoleIndentificator = item.SystemIdentificator, Id = item.Id }).ToList()
            );
        }
    }
}
