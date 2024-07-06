using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.User;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.UserRepository
{
    public class UserRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserDbo>(dbContext, memoryCache), IUserRepository
    {
        public override UserDbo GetEntity(Guid id)
        {
            return _dbContext.Set<UserDbo>()
                .Include(x => x.Person)
                .Include(x => x.Person.PersonAddress.Where(x => x.IsDeleted == false))
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Id == id);
        }
        public override UserDbo GetEntity(bool deleted, Expression<Func<UserDbo, bool>> predicate = null)
        {
            return _dbContext.Set<UserDbo>()
                .Include(x => x.Person)
                .Include(x => x.UserRole)
                .Where(x => x.IsDeleted == deleted)
                .FirstOrDefault(predicate);
        }
    }
}
