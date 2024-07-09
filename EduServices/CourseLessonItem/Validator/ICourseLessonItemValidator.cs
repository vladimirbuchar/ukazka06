using Core.Base.Validator;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItemRepository;
using Services.CourseLessonItem.Dto;

namespace Services.CourseLessonItem.Validator
{
    public interface ICourseLessonItemValidator
        : IBaseValidator<
            CourseLessonItemDbo,
            ICourseLessonItemRepository,
            CourseLessonItemCreateDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto
        > { }
}
