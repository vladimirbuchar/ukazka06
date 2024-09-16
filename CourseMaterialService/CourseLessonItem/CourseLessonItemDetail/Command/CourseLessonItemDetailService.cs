using Core.Base.Command.Detail;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Dto;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Command
{
    public class CourseLessonItemDetailService
        : BaseDetailCommand<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemDetailDto, ICourseLessonItemDetailConvertor>,
            ICourseLessonItemDetailService
    {
        public CourseLessonItemDetailService(ICourseLessonItemRepository repository, ICourseLessonItemDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
