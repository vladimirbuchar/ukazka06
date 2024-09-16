using Core.Base.Validator;
using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Validator
{
    public interface ICourseTableUpdateValidator : IBaseUpdateValidator<CourseTableDbo, CourseTableUpdateDto>
    {
    }
}