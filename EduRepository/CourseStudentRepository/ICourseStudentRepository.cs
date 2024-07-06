using Core.Base.Repository;
using Model.Link;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseStudentRepository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudentDbo>
    {
        HashSet<CourseStudentDbo> GetStudentCourse(Guid userId, bool hideFinishCourse);
    }
}
