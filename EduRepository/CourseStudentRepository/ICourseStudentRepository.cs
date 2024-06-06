using System;
using System.Collections.Generic;
using Core.Base.Repository;
using Model.Tables.Link;

namespace EduRepository.CourseStudentRepository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudentDbo>
    {
        HashSet<CourseStudentDbo> GetAllStudentInCourseTerm(Guid courseTermId);
        HashSet<CourseStudentDbo> GetStudentCourse(Guid userId, bool hideFinishCourse);
    }
}
