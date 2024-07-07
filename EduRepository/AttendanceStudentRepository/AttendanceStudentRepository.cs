using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.AttendanceStudent;

namespace Repository.AttendanceStudentRepository
{
    public class AttendanceStudentRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<AttendanceStudentDbo>(dbContext, memoryCache), IAttendanceStudentRepository { }
}
