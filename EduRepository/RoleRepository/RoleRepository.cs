using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.UserRole;

namespace Repository.RoleRepository
{
    public class RoleRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserRoleDbo>(dbContext, memoryCache), IRoleRepository { }
}
