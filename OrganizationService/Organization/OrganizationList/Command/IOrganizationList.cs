using Core.Base.Command.List;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationList.Dto;
using OrganizationService.Organization.OrganizationList.Filter;

namespace OrganizationService.Organization.OrganizationList.Command
{
    public interface IOrganizationList : IBaseListCommand<OrganizationDbo, OrganizationListDto, OrganizationFilter> { }
}
