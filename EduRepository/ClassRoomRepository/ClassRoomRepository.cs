using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.CourseTermDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.ClassRoomRepository
{
    public class ClassRoomRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<ClassRoomDbo>(dbContext, memoryCache), IClassRoomRepository
    {
        public override ClassRoomDbo GetEntity(Guid id)
        {
            return _dbContext.Set<ClassRoomDbo>().Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<ClassRoomDbo> GetEntities(bool deleted, Expression<Func<ClassRoomDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<ClassRoomDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<ClassRoomDbo>().Where(x => x.Id == objectId).Include(x => x.Branch).FirstOrDefault().Branch.OrganizationId;
        }

        public ClassRoomDbo GetOnlineClassRoom(Guid organizationId)
        {
            return _dbContext.Set<ClassRoomDbo>().Include(x => x.Branch).Where(x => x.IsOnline == true && x.Branch.OrganizationId == organizationId).FirstOrDefault();
        }

        public HashSet<CourseTermDateDbo> GetClassRoomTimeTable(Guid classRoomId)
        {
            return [.. _dbContext.Set<ClassRoomDbo>().Include(x => x.CourseTermDates).FirstOrDefault(x => x.Id == classRoomId).CourseTermDates];
        }
    }
}
