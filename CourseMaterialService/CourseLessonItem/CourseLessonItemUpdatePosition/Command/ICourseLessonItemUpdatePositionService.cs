using Core.Base.Command.Update;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Command
{
    public interface ICourseLessonItemUpdatePositionService : IBaseUpdateCommand<CourseLessonItemDbo, CourseLessonItemUpdatePositionDto> { }
}
