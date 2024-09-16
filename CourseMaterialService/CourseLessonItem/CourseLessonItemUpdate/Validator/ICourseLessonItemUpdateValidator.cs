using Core.Base.Validator;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Validator
{
    public interface ICourseLessonItemUpdateValidator : IBaseUpdateValidator<CourseLessonItemDbo, CourseLessonItemUpdateDto> { }
}
