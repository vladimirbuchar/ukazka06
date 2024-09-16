using Core.Base.Convertor;
using CourseStudyService.Student.StudentCourseList.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseList.Convertor
{
    public interface IStudentCourseListConvertor : IBaseListConvertor<CourseStudentDbo, StudentCourseListDto>
    {
    }
}