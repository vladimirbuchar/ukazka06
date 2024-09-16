using Core.Base.Convertor;
using CourseStudyService.CourseStudy.CourseMenu.Dto;
using Model.Edu.CourseLesson;

namespace CourseStudyService.CourseStudy.CourseMenu.Convertor
{
    public interface ICourseMenuConvertor : IBaseListConvertor<CourseLessonDbo, CourseMenuItemDto>
    {
    }
}