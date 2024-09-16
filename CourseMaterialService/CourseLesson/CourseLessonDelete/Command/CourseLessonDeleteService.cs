using Core.Base.Command.Delete;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonDelete.Command
{
    public class CourseLessonDeleteService : BaseDeleteCommand<CourseLessonDbo, ICourseLessonRepository>, ICourseLessonDeleteService
    {
        public CourseLessonDeleteService(ICourseLessonRepository repository)
            : base(repository) { }
    }
}
