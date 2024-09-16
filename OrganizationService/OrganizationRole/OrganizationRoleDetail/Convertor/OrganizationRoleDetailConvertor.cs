using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Dto;

namespace OrganizationService.OrganizationRole.OrganizationRoleDetail.Convertor
{
    public class OrganizationRoleDetailConvertor : IOrganizationRoleDetailConvertor
    {
        public Task<OrganizationRoleDetailDto> ConvertToWebModel(OrganizationRoleDbo detail, List<string> culture)
        {
            return Task.FromResult(new OrganizationRoleDetailDto() { Id = detail.Id, RoleIndentificator = detail.SystemIdentificator });
        }
    }
}
