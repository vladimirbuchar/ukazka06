﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentGroup;

namespace EduRepository.StudentGroupRepository
{
    public class StudentGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentGroupDbo>(dbContext, memoryCache), IStudentGroupRepository
    {
        public override StudentGroupDbo GetEntity(Guid id)
        {
            return _dbContext.Set<StudentGroupDbo>().Where(x => x.Id == id).Include(x => x.StudentGroupTranslations).ThenInclude(x => x.Culture).FirstOrDefault();
        }

        public override HashSet<StudentGroupDbo> GetEntities(bool deleted, Expression<Func<StudentGroupDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<StudentGroupDbo>().Where(predicate).Where(x => x.IsDeleted == deleted).Include(x => x.StudentGroupTranslations).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<StudentGroupDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
