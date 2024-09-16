using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleList.Dto;

namespace OrganizationService.OrganizationRole.OrganizationRoleList.Command
{
    public interface IOrganizationRoleListService : IBaseListCommand<OrganizationRoleDbo, OrganizationRoleListDto, RequestFilter> { }
}
