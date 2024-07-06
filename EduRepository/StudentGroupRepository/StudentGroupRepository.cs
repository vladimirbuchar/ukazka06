using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.StudentGroupRepository
{
    public class StudentGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentGroupDbo>(dbContext, memoryCache), IStudentGroupRepository
    {
        public override StudentGroupDbo GetEntity(Guid id)
        {
            return _dbContext.Set<StudentGroupDbo>()
                .Include(x => x.StudentGroupTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<StudentGroupDbo> GetEntities(bool deleted, Expression<Func<StudentGroupDbo, bool>> predicate = null, Expression<Func<StudentGroupDbo, object>> orderBy = null, Expression<Func<StudentGroupDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<StudentGroupDbo>()
                .Include(x => x.StudentGroupTranslations.Where(x => x.IsDeleted == false)).
                ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<StudentGroupDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
