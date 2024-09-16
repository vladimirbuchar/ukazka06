using Core.Base.Convertor;
using CourseStudyService.Student.StudentCourseUpdate.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseUpdate.Convertor
{
    public interface IStudentCourseUpdateConvertor : IBaseUpdateConvertor<CourseStudentDbo, StudentCourseUpdateDto>
    {
    }
}