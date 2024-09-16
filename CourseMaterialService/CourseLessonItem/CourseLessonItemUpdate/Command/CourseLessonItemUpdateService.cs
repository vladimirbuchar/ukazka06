using Core.Base.Command.Update;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Validator;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Command
{
    public class CourseLessonItemUpdateService
        : BaseUpdateCommand<
            CourseLessonItemDbo,
            ICourseLessonItemRepository,
            CourseLessonItemUpdateDto,
            ICourseLessonItemUpdateConvertor,
            ICourseLessonItemUpdateValidator

        >,
            ICourseLessonItemUpdateService
    {
        public CourseLessonItemUpdateService(
            ICourseLessonItemRepository repository,
            ICourseLessonItemUpdateConvertor convertor,
            ICourseLessonItemUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
