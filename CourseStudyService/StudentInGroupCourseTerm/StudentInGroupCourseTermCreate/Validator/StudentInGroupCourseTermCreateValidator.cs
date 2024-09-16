using Core.Base.Validator;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using Model.Link;
using Repository.StudentInGroupCourseTerm;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Validator
{
    public class StudentInGroupCourseTermCreateValidator
        : BaseCreateValidator<StudentInGroupCourseTermDbo, IStudentInGroupCourseTermRepository, StudentInGroupCourseTermCreateDto>,
            IStudentInGroupCourseTermCreateValidator
    {
        public StudentInGroupCourseTermCreateValidator(IStudentInGroupCourseTermRepository repository)
            : base(repository) { }
    }
}
