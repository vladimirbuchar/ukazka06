using Core.Base.Convertor;
using EduServices.Organization.Dto;
using Model.Tables.Edu.Organization;

namespace EduServices.Organization.Convertor
{
    public interface IOrganizationConvertor : IBaseConvertor<OrganizationDbo, OrganizationCreateDto, OrganizationListDto, OrganizationDetailDto, OrganizationUpdateDto>
    {
        OrganizationDetailWebDto ConvertToWebModelWeb(OrganizationDbo getOrganizationDetail);
        OrganizationCreateDto ConvertToWebModelWebForUser(OrganizationCreateByUserDto organizationCreateByUser);
    }
}
