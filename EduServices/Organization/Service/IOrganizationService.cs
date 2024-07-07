using Core.Base.Service;
using Model.Edu.Organization;
using Services.Organization.Dto;
using System;

namespace Services.Organization.Service
{
    public interface IOrganizationService : IBaseService<OrganizationDbo, OrganizationCreateDto, OrganizationListDto, OrganizationDetailDto, OrganizationUpdateDto, OrganizationFileRepositoryDbo>
    {
        OrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
    }
}
