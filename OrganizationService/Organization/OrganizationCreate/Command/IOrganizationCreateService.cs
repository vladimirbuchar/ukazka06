using Core.Base.Command.Create;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationCreate.Dto;

namespace OrganizationService.Organization.OrganizationCreate.Command
{
    public interface IOrganizationCreateService : IBaseCreateCommand<OrganizationDbo, OrganizationCreateDto> { }
}
