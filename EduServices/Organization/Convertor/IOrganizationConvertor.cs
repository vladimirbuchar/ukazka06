using Core.Base.Convertor;
using Model.Edu.Organization;
using Services.Organization.Dto;

namespace Services.Organization.Convertor
{
    public interface IOrganizationConvertor
        : IBaseConvertor<OrganizationDbo, OrganizationCreateDto, OrganizationListDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        OrganizationDetailWebDto ConvertToWebModelWeb(OrganizationDbo getOrganizationDetail);
        OrganizationCreateDto ConvertToWebModelWebForUser(OrganizationCreateByUserDto organizationCreateByUser);
    }
}
