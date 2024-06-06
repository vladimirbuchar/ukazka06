using System;
using System.Collections.Generic;
using Core.Base.Repository;
using Model.Tables.Edu.CourseMaterial;

namespace EduRepository.CourseMaterialRepository
{
    public interface ICourseMaterialRepository : IBaseRepository<CourseMaterialDbo>
    {
        HashSet<CourseMaterialFileRepositoryDbo> GetFiles(Guid courseMaterialId);
    }
}
