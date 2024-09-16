using Core.Base.Convertor;
using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Convertor
{
    public interface ICourseTableUpdateConvertor : IBaseUpdateConvertor<CourseTableDbo, CourseTableUpdateDto>
    {
    }
}