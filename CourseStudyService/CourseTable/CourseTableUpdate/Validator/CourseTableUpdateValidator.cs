using Core.Base.Validator;
using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using Model.Edu.CourseTable;
using Repository.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Validator
{
    public class CourseTableUpdateValidator : BaseUpdateValidator<CourseTableDbo, ICourseTableRepository, CourseTableUpdateDto>, ICourseTableUpdateValidator
    {
        public CourseTableUpdateValidator(ICourseTableRepository repository) : base(repository)
        {
        }
    }
}
