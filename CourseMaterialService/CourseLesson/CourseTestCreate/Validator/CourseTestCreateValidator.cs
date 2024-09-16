using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using Model.Edu.CourseTest;
using Repository.Test;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Validator
{
    public class CourseTestCreateValidator : BaseCreateValidator<CourseTestDbo, ITestRepository, CourseTestCreateDto>, ICourseTestCreateValidator
    {
        public CourseTestCreateValidator(ITestRepository repository)
            : base(repository) { }
    }
}
