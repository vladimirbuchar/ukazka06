using Core.Base.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Convertor
{
    public interface ICourseLessonItemUpdateConvertor : IBaseUpdateConvertor<CourseLessonItemDbo, CourseLessonItemUpdateDto> { }
}
