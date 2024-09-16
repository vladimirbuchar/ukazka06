using Core.Base.Command.Detail;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Dto;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Command
{
    public interface ICourseLessonItemDetailService : IBaseDetailCommand<CourseLessonItemDbo, CourseLessonItemDetailDto> { }
}
