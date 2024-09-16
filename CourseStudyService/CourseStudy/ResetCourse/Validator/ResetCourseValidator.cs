using Core.Base.Validator;
using CourseStudyService.CourseStudy.ResetCourse.Dto;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.CourseStudy.ResetCourse.Validator
{
    public class ResetCourseValidator : BaseUpdateValidator<CourseStudentDbo, ICourseStudentRepository, ResetCourseDto>, IResetCourseValidator
    {
        public ResetCourseValidator(ICourseStudentRepository repository) : base(repository)
        {
        }
    }
}
