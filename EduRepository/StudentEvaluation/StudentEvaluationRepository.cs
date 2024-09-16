using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentEvaluation;
using System.Linq;

namespace Repository.StudentEvaluation
{
    public class StudentEvaluationRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentEvaluationDbo>(dbContext, memoryCache),
            IStudentEvaluationRepository
    {

        protected override IQueryable<StudentEvaluationDbo> PrepareListQuery()
        {
            return _dbContext.Set<StudentEvaluationDbo>().Include(x => x.CourseStudent).ThenInclude(x => x.UserInOrganization).ThenInclude(x => x.User).ThenInclude(x => x.Person);
        }
    }
}
