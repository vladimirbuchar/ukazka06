using System;
using Core.Base.Service;
using Model.Edu.Organization;
using Services.Organization.Dto;
using Services.Organization.Filter;

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
        OrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
    }
}
