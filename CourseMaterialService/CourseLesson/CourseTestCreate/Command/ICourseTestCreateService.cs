using Core.Base.Command.Create;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Command
{
    public interface ICourseTestCreateService : IBaseCreateCommand<CourseTestDbo, CourseTestCreateDto> { }
}
