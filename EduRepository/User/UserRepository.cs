using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.User;
using System.Linq;

namespace Repository.User
{
    public class UserRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserDbo>(dbContext, memoryCache), IUserRepository
    {
        protected override IQueryable<UserDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<UserDbo>()
                .Include(x => x.Person)
                .ThenInclude(x => x.PersonAddress.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.AddressType)
                .Include(x => x.UserRole)
                .Include(x => x.UserInOrganizations.Where(x => x.IsDeleted == false));
        }
    }
}
