using Core.Base.Command.Restore;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonRestore.Command
{
    public class CourseLessonRestoreService : BaseRestoreCommand<CourseLessonDbo, ICourseLessonRepository>, ICourseLessonRestoreService
    {
        public CourseLessonRestoreService(ICourseLessonRepository repository)
            : base(repository) { }
    }
}
