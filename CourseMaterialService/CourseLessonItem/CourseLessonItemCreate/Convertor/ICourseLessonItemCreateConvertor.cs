using Core.Base.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Convertor
{
    public interface ICourseLessonItemCreateConvertor : IBaseCreateConvertor<CourseLessonItemDbo, CourseLessonItemCreateDto> { }
}
