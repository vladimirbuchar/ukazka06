using System;
using System.Collections.Generic;
using Core.Base.Repository;
using Model.Link;

namespace Repository.CourseStudentRepository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudentDbo>
    {
        HashSet<CourseStudentDbo> GetStudentCourse(Guid userId, bool hideFinishCourse);
    }
}
