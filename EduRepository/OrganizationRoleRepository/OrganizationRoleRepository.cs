using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.OrganizationRole;

namespace EduRepository.OrganizationRoleRepository
{
    public class OrganizationRoleRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationRoleDbo>(dbContext, memoryCache), IOrganizationRoleRepository { }
}
