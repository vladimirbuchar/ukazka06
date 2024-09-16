using Core.Base.Command.Create;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Command
{
    public interface ICourseLessonItemCreateService : IBaseCreateCommand<CourseLessonItemDbo, CourseLessonItemCreateDto> { }
}
