using Core.Base.Command.List;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Dto;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Filter;

namespace OrganizationService.OrganizationCulture.OrganizationCultureList.Command
{
    public interface IOrganizationCultureListService
        : IBaseListCommand<OrganizationCultureDbo, OrganizationCultureListDto, OrganizationCultureFilter>
    { }
}
