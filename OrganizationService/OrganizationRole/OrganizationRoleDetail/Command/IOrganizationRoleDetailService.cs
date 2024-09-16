using Core.Base.Command.Detail;
using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Dto;

namespace OrganizationService.OrganizationRole.OrganizationRoleDetail.Command
{
    public interface IOrganizationRoleDetailService : IBaseDetailCommand<OrganizationRoleDbo, OrganizationRoleDetailDto> { }
}
