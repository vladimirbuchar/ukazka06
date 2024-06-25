using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.User;
using System;
using System.Linq;

namespace EduRepository.UserRepository
{
    public class UserRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserDbo>(dbContext, memoryCache), IUserRepository
    {
        public UserDbo LoginUser(string login, string password)
        {
            return _dbContext.Set<UserDbo>()
                .Include(x => x.Person)
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.UserEmail == login && x.UserPassword == password && x.IsActive == true && x.IsDeleted == false && x.AllowCLassicLogin == true);
        }


        public override UserDbo GetEntity(Guid id)
        {
            return _dbContext.Set<UserDbo>()
                .Include(x => x.Person).Include(x => x.Person.PersonAddress.Where(x => x.IsDeleted == false))
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

    }
}
