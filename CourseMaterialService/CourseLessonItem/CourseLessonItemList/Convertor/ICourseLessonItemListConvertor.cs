using Core.Base.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Convertor
{
    public interface ICourseLessonItemListConvertor : IBaseListConvertor<CourseLessonItemDbo, CourseLessonItemListDto> { }
}
