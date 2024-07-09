using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.User;

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

        public override UserDbo GetEntity(bool deleted, Expression<Func<UserDbo, bool>> predicate = null)
        {
            return _dbContext
                .Set<UserDbo>()
                .Include(x => x.Person)
                .Include(x => x.UserRole)
                .Where(x => x.IsDeleted == deleted)
                .FirstOrDefault(predicate);
        }
    }
}
