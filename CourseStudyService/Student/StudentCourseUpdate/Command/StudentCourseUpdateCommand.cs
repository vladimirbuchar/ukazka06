using Core.Base.Command.Update;
using CourseStudyService.Student.StudentCourseUpdate.Convertor;
using CourseStudyService.Student.StudentCourseUpdate.Dto;
using CourseStudyService.Student.StudentCourseUpdate.Validator;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.Student.StudentCourseUpdate.Command
{
    public class StudentCourseUpdateCommand : BaseUpdateCommand<CourseStudentDbo, ICourseStudentRepository, StudentCourseUpdateDto, IStudentCourseUpdateConvertor, IStudentCourseUpdateValidator>, IStudentCourseUpdateCommand
    {
        public StudentCourseUpdateCommand(ICourseStudentRepository repository, IStudentCourseUpdateConvertor convertor, IStudentCourseUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
