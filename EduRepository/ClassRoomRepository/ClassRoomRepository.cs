using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.ClassRoomRepository
{
    public class ClassRoomRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<ClassRoomDbo>(dbContext, memoryCache), IClassRoomRepository
    {
        public override ClassRoomDbo GetEntity(Guid id)
        {
            return _dbContext.Set<ClassRoomDbo>()
                .Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<ClassRoomDbo> GetEntities(bool deleted, Expression<Func<ClassRoomDbo, bool>> predicate = null, Expression<Func<ClassRoomDbo, object>> orderBy = null, Expression<Func<ClassRoomDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<ClassRoomDbo>()
                .Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<ClassRoomDbo>()
                .Where(x => x.Id == objectId)
                .Include(x => x.Branch)
                .FirstOrDefault().Branch.OrganizationId;
        }

        public override ClassRoomDbo GetEntity(bool deleted, Expression<Func<ClassRoomDbo, bool>> predicate = null)
        {
            return _dbContext.Set<ClassRoomDbo>()
                .Include(x => x.Branch)
                .Include(x => x.CourseTermDates.Where(y => y.IsDeleted == false))
                .Where(x => x.IsDeleted == deleted)
                .FirstOrDefault(predicate);
        }
    }
}
