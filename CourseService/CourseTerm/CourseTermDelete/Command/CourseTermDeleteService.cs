using Core.Base.Command.Delete;
using Model.Edu.CourseTerm;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermDelete.Command
{
    public class CourseTermDeleteService : BaseDeleteCommand<CourseTermDbo, ICourseTermRepository>, ICourseTermDeleteService
    {
        public CourseTermDeleteService(ICourseTermRepository repository)
            : base(repository) { }
    }
}
