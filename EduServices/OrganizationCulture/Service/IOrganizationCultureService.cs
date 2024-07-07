using Core.Base.Service;
using Model.Link;
using Services.OrganizationCulture.Dto;

namespace Services.OrganizationCulture.Service
{
    public interface IOrganizationCultureService
        : IBaseService<OrganizationCultureDbo, OrganizationCultureCreateDto, OrganizationCultureListDto, OrganizationCultureDetailDto, OrganizationCultureUpdateDto> { }
}
