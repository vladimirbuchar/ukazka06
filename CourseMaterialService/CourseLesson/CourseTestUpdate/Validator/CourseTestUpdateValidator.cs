using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;
using Model.Edu.CourseTest;
using Repository.Test;

namespace CourseMaterialService.CourseLesson.CourseTestUpdate.Validator
{
    public class CourseTestUpdateValidator : BaseUpdateValidator<CourseTestDbo, ITestRepository, CourseTestUpdateDto>, ICourseTestUpdateValidator
    {
        public CourseTestUpdateValidator(ITestRepository repository)
            : base(repository) { }
    }
}
