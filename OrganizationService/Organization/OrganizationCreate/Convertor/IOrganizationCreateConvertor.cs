using Core.Base.Convertor;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationCreate.Dto;

namespace OrganizationService.Organization.OrganizationCreate.Convertor
{
    public interface IOrganizationCreateConvertor : IBaseCreateConvertor<OrganizationDbo, OrganizationCreateDto> { }
}
