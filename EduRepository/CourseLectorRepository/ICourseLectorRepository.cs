using System;
using System.Collections.Generic;
using Core.Base.Repository;
using Model.Tables.Link;

namespace EduRepository.CourseLectorRepository
{
    public interface ICourseLectorRepository : IBaseRepository<CourseLectorDbo>
    {
        HashSet<CourseLectorDbo> GetLectorCourse(Guid userId);
    }
}
