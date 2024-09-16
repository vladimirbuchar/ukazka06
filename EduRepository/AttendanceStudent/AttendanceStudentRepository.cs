using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.AttendanceStudent;

namespace Repository.AttendanceStudent
{
    public class AttendanceStudentRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentAttendanceDbo>(dbContext, memoryCache),
            IAttendanceStudentRepository
    { }
}
