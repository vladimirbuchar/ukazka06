using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.AttendanceStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.AttendanceStudentRepository
{
    public class StudentAttendanceRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentAttendanceDbo>(dbContext, memoryCache), IStudentAttendanceRepository
    {
        public override StudentAttendanceDbo GetEntity(Guid id)
        {
            return _dbContext.Set<StudentAttendanceDbo>().FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<StudentAttendanceDbo> GetEntities(bool deleted, Expression<Func<StudentAttendanceDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<StudentAttendanceDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)];
        }
    }
}
