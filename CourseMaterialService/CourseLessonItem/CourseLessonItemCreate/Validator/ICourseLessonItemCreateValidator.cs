using Core.Base.Validator;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Validator
{
    public interface ICourseLessonItemCreateValidator : IBaseCreateValidator<CourseLessonItemDbo, CourseLessonItemCreateDto> { }
}
