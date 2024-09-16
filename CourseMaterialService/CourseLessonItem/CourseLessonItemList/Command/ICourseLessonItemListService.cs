using Core.Base.Command.List;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Dto;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Filter;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Command
{
    public interface ICourseLessonItemListService : IBaseListCommand<CourseLessonItemDbo, CourseLessonItemListDto, CourseLessonItemFilter> { }
}
