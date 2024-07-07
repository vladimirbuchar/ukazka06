using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.CourseStudentRepository
{
    public class CourseStudentRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseStudentDbo>(dbContext, memoryCache), ICourseStudentRepository
    {
        public override HashSet<CourseStudentDbo> GetEntities(bool deleted, Expression<Func<CourseStudentDbo, bool>> predicate = null, Expression<Func<CourseStudentDbo, object>> orderBy = null, Expression<Func<CourseStudentDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<CourseStudentDbo>()

                .Include(x => x.UserInOrganization)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Person)
                .Include(x => x.CourseTerm)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ];
        }

        public HashSet<CourseStudentDbo> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return
            [
                .. _dbContext
                    .Set<CourseStudentDbo>()
                    .Include(x => x.UserInOrganization)
                    .ThenInclude(x => x.User)
                    .ThenInclude(x => x.Person)
                    .Include(x => x.CourseTerm)
                    .Where(x => x.CourseTermId == courseTermId && x.IsDeleted == false)
            ];
        }

        public HashSet<CourseStudentDbo> GetStudentCourse(Guid userId, bool hideFinishCourse)
        {
            HashSet<CourseStudentDbo> courses =
            [
                .. _dbContext
                    .Set<CourseStudentDbo>()
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x=>x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                    .ThenInclude(x=>x.Culture)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x => x.Branch)
                    .ThenInclude(x=>x.BranchTranslations.Where(x => x.IsDeleted == false))
                    .ThenInclude(x=>x.Culture)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.ClassRoom)
                    .ThenInclude(x => x.Branch)
                    .ThenInclude(x=>x.Organization)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.TimeFrom)
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.TimeTo)
                    .Include(x => x.UserInOrganization)
                    .Where(x=>x.UserInOrganization.UserId  == userId)
            ];
            if (hideFinishCourse)
            {
                courses = courses.Where(x => x.CourseFinish == false).ToHashSet();
            }
            return [.. courses.OrderBy(x => x.CourseFinish)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseStudentDbo>()
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.Course)
                .FirstOrDefault(x => x.Id == objectId).CourseTerm.Course.OrganizationId;
        }
    }
}
