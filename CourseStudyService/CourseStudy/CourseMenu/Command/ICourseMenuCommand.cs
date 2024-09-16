using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.CourseStudy.CourseMenu.Dto;
using Model.Edu.CourseLesson;

namespace CourseStudyService.CourseStudy.CourseMenu.Command
{
    public interface ICourseMenuCommand : IBaseListCommand<CourseLessonDbo, CourseMenuItemDto, RequestFilter>
    {
    }
}