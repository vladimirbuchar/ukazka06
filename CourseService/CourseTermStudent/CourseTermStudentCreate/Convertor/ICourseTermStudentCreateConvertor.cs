using Core.Base.Convertor;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Convertor
{
    public interface ICourseTermStudentCreateConvertor : IBaseCreateConvertor<CourseStudentDbo, AddCourseTermStudentDto> { }
}
