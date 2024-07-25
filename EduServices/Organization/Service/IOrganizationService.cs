using Core.Base.Service;
using Model.Edu.Organization;
using Services.Organization.Dto;
using Services.Organization.Filter;
using System;
using System.Threading.Tasks;

namespace Services.Organization.Service
{
    public interface IOrganizationService
        : IBaseService<
            OrganizationDbo,
            OrganizationCreateDto,
            OrganizationListDto,
            OrganizationDetailDto,
            OrganizationUpdateDto,
            OrganizationFileRepositoryDbo,
            OrganizationFilter
        >
    {
        Task<OrganizationDetailWebDto> GetOrganizationDetailWeb(Guid organizationId);
    }
}
