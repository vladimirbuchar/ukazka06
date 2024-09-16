using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleList.Convertor;
using OrganizationService.OrganizationRole.OrganizationRoleList.Dto;
using Repository.OrganizationRole;

namespace OrganizationService.OrganizationRole.OrganizationRoleList.Command
{
    public class OrganizationRoleListService
        : BaseListCommand<OrganizationRoleDbo, IOrganizationRoleRepository, OrganizationRoleListDto, IOrganizationRoleListConvertor, RequestFilter>,
            IOrganizationRoleListService
    {
        public OrganizationRoleListService(IOrganizationRoleRepository repository, IOrganizationRoleListConvertor convertor)
            : base(repository, convertor) { }
    }
}
