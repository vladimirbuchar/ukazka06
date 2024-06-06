using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.UserRole;

namespace EduRepository.RoleRepository
{
    public class RoleRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserRoleDbo>(dbContext, memoryCache), IRoleRepository { }
}
