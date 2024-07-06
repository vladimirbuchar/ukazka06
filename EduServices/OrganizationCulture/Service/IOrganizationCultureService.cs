using Core.Base.Service;
using EduServices.OrganizationCulture.Dto;
using Model.Link;

namespace EduServices.OrganizationCulture.Service
{
    public interface IOrganizationCultureService
        : IBaseService<OrganizationCultureDbo, OrganizationCultureCreateDto, OrganizationCultureListDto, OrganizationCultureDetailDto, OrganizationCultureUpdateDto> { }
}
