using Core.Base.Command.Detail;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationDetail.Dto;

namespace OrganizationService.Organization.OrganizationDetail.Command
{
    public interface IOrganizationDetailService : IBaseDetailCommand<OrganizationDbo, OrganizationDetailDto> { }
}
