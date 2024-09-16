using Core.Base.Command.Create;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Command
{
    public interface IOrganizationCultureCreateService : IBaseCreateCommand<OrganizationCultureDbo, OrganizationCultureCreateDto> { }
}
