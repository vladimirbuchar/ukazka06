using Core.Base.Command.Update;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Command
{
    public interface ICourseLessonItemUpdateService : IBaseUpdateCommand<CourseLessonItemDbo, CourseLessonItemUpdateDto> { }
}
