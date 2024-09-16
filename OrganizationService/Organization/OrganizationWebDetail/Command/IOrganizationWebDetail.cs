using Core.Base.Command.Detail;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationWebDetail.Dto;

namespace OrganizationService.Organization.OrganizationWebDetail.Command
{
    public interface IOrganizationWebDetail : IBaseDetailCommand<OrganizationDbo, OrganizationDetailWebDto> { }
}
