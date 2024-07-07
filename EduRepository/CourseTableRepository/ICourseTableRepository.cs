using System;
using Core.Base.Repository;
using Model.Edu.CourseTable;

namespace Repository.CourseTableRepository
{
    public interface ICourseTableRepository : IBaseRepository<CourseTableDbo>
    {
        void UpdateActualTable(Guid courseTermid, string img);
        string GetActualTable(Guid courseTermid);
    }
}
