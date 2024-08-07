﻿using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.ClassRoom;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.ClassRoomRepository
{
    public class ClassRoomRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<ClassRoomDbo>(dbContext, memoryCache),
            IClassRoomRepository
    {
        protected override IQueryable<ClassRoomDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<ClassRoomDbo>().Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        protected override IQueryable<ClassRoomDbo> PrepareListQuery()
        {
            return _dbContext.Set<ClassRoomDbo>().Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<ClassRoomDbo>().Where(x => x.Id == objectId).Include(x => x.Branch).FirstOrDefaultAsync()).Branch.OrganizationId;
        }

        public override async Task<ClassRoomDbo> GetEntity(bool deleted, Expression<Func<ClassRoomDbo, bool>> predicate = null)
        {
            return await _dbContext
                .Set<ClassRoomDbo>()
                .Include(x => x.Branch)
                .Include(x => x.CourseTermDates.Where(y => y.IsDeleted == false))
                .ThenInclude(x => x.CourseTerm)
                .Where(x => x.IsDeleted == deleted)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
