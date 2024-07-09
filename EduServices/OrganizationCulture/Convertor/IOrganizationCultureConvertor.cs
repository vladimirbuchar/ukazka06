using Core.Base.Convertor;
using Model.Link;
using Services.OrganizationCulture.Dto;

namespace Services.OrganizationCulture.Convertor
{
    public interface IOrganizationCultureConvertor
        : IBaseConvertor<
            OrganizationCultureDbo,
            OrganizationCultureCreateDto,
            OrganizationCultureListDto,
            OrganizationCultureDetailDto,
            OrganizationCultureUpdateDto
        > { }
}
