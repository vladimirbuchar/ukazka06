using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.User;
using System.Linq;

namespace Repository.UserRepository
{
    public class UserRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserDbo>(dbContext, memoryCache), IUserRepository
    {
        protected override IQueryable<UserDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<UserDbo>()
                .Include(x => x.Person)
                .Include(x => x.Person.PersonAddress.Where(x => x.IsDeleted == false))
                .Include(x => x.UserRole);
        }
    }
}
