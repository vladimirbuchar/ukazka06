using Core.Base.Command.Restore;
using Model.Edu.Course;
using Repository.Course;

namespace CourseService.Course.CourseRestore.Command
{
    public class CourseRestoreService : BaseRestoreCommand<CourseDbo, ICourseRepository>, ICourseRestoreService
    {
        public CourseRestoreService(ICourseRepository repository)
            : base(repository) { }
    }
}
