using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Link;

namespace EduRepository.StudentInGroupCourseTerm
{
    public class StudentInGroupCourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentInGroupCourseTermDbo>(dbContext, memoryCache),
            IStudentInGroupCourseTermRepository { }
}
