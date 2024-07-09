using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Branch;
using Model.Link;

namespace Repository.CourseLectorRepository
{
    public class CourseLectorRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseLectorDbo>(dbContext, memoryCache),
            ICourseLectorRepository
    {
        protected override IQueryable<CourseLectorDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseLectorDbo>()
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.Organization)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeFrom)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeTo)
                .Include(x => x.UserInOrganization);
        }
    }
}
