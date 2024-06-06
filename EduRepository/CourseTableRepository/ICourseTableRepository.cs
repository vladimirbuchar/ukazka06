using System;
using Core.Base.Repository;
using Model.Tables.Edu.CourseTable;

namespace EduRepository.CourseTableRepository
{
    public interface ICourseTableRepository : IBaseRepository<CourseTableDbo>
    {
        void UpdateActualTable(Guid courseTermid, string img);
        string GetActualTable(Guid courseTermid);
    }
}
