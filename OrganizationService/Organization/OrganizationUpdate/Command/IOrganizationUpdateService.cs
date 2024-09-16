using Core.Base.Command.Update;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationUpdate.Dto;

namespace OrganizationService.Organization.OrganizationUpdate.Command
{
    public interface IOrganizationUpdateService : IBaseUpdateCommand<OrganizationDbo, OrganizationUpdateDto> { }
}
