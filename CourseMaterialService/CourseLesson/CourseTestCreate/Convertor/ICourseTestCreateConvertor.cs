using Core.Base.Convertor;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Convertor
{
    public interface ICourseTestCreateConvertor : IBaseCreateConvertor<CourseTestDbo, CourseTestCreateDto> { }
}
