using Core.Base.Convertor;
using EduServices.OrganizationCulture.Dto;
using Model.Link;

namespace EduServices.OrganizationCulture.Convertor
{
    public interface IOrganizationCultureConvertor
        : IBaseConvertor<OrganizationCultureDbo, OrganizationCultureCreateDto, OrganizationCultureListDto, OrganizationCultureDetailDto, OrganizationCultureUpdateDto> { }
}
