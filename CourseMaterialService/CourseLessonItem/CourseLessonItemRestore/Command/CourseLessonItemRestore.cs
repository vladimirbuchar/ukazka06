using Core.Base.Command.Restore;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemRestore.Command
{
    public class CourseLessonItemRestore : BaseRestoreCommand<CourseLessonItemDbo, ICourseLessonItemRepository>, ICourseLessonItemRestoreService
    {
        public CourseLessonItemRestore(ICourseLessonItemRepository repository)
            : base(repository) { }
    }
}
