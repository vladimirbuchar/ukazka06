using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTermDate;

namespace EduRepository.CourseTermDateRepository
{
    public class CourseTermDateRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTermDateDbo>(dbContext, memoryCache), ICourseTermDateRepository
    {

    }
}
