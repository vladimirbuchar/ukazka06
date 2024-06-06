using System;
using Core.Base.Repository;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;

namespace EduRepository.OrganizationRepository
{
    public interface IOrganizationRepository : IBaseRepository<OrganizationDbo>
    {
        LicenseDbo GetLicenseByOrganization(Guid organizationId);
    }
}
