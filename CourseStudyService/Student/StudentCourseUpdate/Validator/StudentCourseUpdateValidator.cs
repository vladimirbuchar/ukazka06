using Core.Base.Validator;
using CourseStudyService.Student.StudentCourseUpdate.Dto;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.Student.StudentCourseUpdate.Validator
{
    public class StudentCourseUpdateValidator : BaseUpdateValidator<CourseStudentDbo, ICourseStudentRepository, StudentCourseUpdateDto>, IStudentCourseUpdateValidator
    {
        public StudentCourseUpdateValidator(ICourseStudentRepository repository) : base(repository)
        {
        }
    }
}
