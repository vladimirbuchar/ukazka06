using Core.Base.Convertor;
using CourseStudyService.Student.StudentCourseDetail.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseDetail.Convertor
{
    public interface IStudentCourseDetailConvertor : IBaseDetailConvertor<CourseStudentDbo, StudentCourseDetailDto>
    {
    }
}