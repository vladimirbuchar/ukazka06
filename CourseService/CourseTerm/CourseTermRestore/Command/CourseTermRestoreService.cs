using Core.Base.Command.Restore;
using Model.Edu.CourseTerm;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermRestore.Command
{
    public class CourseTermRestoreService : BaseRestoreCommand<CourseTermDbo, ICourseTermRepository>, ICourseTermRestoreService
    {
        public CourseTermRestoreService(ICourseTermRepository repository)
            : base(repository) { }
    }
}
