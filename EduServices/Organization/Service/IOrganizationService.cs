using System;
using Core.Base.Service;
using Model.Edu.Organization;
using Services.Organization.Dto;

namespace Services.Organization.Service
{
    public interface IOrganizationService : IBaseService<OrganizationDbo, OrganizationCreateDto, OrganizationListDto, OrganizationDetailDto, OrganizationUpdateDto, OrganizationFileRepositoryDbo>
    {
        OrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
    }
}
