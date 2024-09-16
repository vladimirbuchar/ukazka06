using Core.Base.Convertor;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationUpdate.Dto;

namespace OrganizationService.Organization.OrganizationUpdate.Convertor
{
    public interface IOrganizationUpdateConvertor : IBaseUpdateConvertor<OrganizationDbo, OrganizationUpdateDto> { }
}
