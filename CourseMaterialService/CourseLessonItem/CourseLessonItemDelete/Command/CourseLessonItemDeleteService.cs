using Core.Base.Command.Delete;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemDelete.Command
{
    public class CourseLessonItemDeleteService : BaseDeleteCommand<CourseLessonItemDbo, ICourseLessonItemRepository>, ICourseLessonItemDeleteService
    {
        public CourseLessonItemDeleteService(ICourseLessonItemRepository repository)
            : base(repository) { }
    }
}
