using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduRepository.CourseLectorRepository
{
    public class CourseLectorRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseLectorDbo>(dbContext, memoryCache), ICourseLectorRepository
    {
        public HashSet<CourseLectorDbo> GetLectorCourse(Guid userId)
        {
            return
            [
                .. _dbContext
                    .Set<CourseLectorDbo>()
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x=>x.ClassRoomTranslations)
                    .ThenInclude(x=>x.Culture)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x => x.Branch)
                    .ThenInclude(x => x.BranchTranslations)
                    .ThenInclude(x=>x.Culture)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x => x.Branch)
                    .ThenInclude(x=>x.Organization)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.TimeFrom)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.TimeTo)
                    .Include(x=>x.UserInOrganization)
                    .Where(x=>x.UserInOrganization.UserId == userId)

            ];
        }
    }
}
