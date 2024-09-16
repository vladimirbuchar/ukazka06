using Core.Base.Command.Update;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Command
{
    public interface IOrganizationCultureUpdateService : IBaseUpdateCommand<OrganizationCultureDbo, OrganizationCultureUpdateDto> { }
}
