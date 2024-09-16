using Core.Base.Command.Delete;
using Model.Edu.Course;
using Repository.Course;

namespace CourseService.Course.CourseDelete.Command
{
    public class CourseDeleteService : BaseDeleteCommand<CourseDbo, ICourseRepository>, ICourseDeleteService
    {
        public CourseDeleteService(ICourseRepository repository)
            : base(repository) { }
    }
}
