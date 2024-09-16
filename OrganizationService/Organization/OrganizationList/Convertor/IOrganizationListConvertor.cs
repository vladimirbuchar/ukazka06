using Core.Base.Convertor;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationList.Dto;

namespace OrganizationService.Organization.OrganizationList.Convertor
{
    public interface IOrganizationListConvertor : IBaseListConvertor<OrganizationDbo, OrganizationListDto> { }
}
