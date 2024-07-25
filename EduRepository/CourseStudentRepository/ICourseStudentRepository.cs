using Core.Base.Repository;
using Model.Link;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.CourseStudentRepository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudentDbo>
    {
        Task<List<CourseStudentDbo>> GetStudentCourse(Guid userId, bool hideFinishCourse);
    }
}
