using System;
using Core.Base.Service;
using EduServices.Organization.Dto;
using Model.Tables.Edu.Organization;

namespace EduServices.Organization.Service
{
    public interface IOrganizationService : IBaseService<OrganizationDbo, OrganizationCreateDto, OrganizationListDto, OrganizationDetailDto, OrganizationUpdateDto, OrganizationFileRepositoryDbo>
    {
        OrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
    }
}
