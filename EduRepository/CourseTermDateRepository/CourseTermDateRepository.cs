using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTermDate;

namespace Repository.CourseTermDateRepository
{
    public class CourseTermDateRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTermDateDbo>(dbContext, memoryCache), ICourseTermDateRepository { }
}
