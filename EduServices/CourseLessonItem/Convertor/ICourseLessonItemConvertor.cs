using Core.Base.Convertor;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;

namespace Services.CourseLessonItem.Convertor
{
    public interface ICourseLessonItemConvertor
        : IBaseConvertor<
            CourseLessonItemDbo,
            CourseLessonItemCreateDto,
            CourseLessonItemListDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto
        > { }
}
