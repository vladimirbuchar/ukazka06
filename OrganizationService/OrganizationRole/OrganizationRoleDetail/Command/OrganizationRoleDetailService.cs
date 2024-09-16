using Core.Base.Command.Detail;
using Model.Edu.OrganizationRole;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Convertor;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Dto;
using Repository.OrganizationRole;

namespace OrganizationService.OrganizationRole.OrganizationRoleDetail.Command
{
    public class OrganizationRoleDetailService
        : BaseDetailCommand<OrganizationRoleDbo, IOrganizationRoleRepository, OrganizationRoleDetailDto, IOrganizationRoleDetailConvertor>,
            IOrganizationRoleDetailService
    {
        public OrganizationRoleDetailService(IOrganizationRoleRepository repository, IOrganizationRoleDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
