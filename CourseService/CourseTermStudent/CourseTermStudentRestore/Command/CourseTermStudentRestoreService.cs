using Core.Base.Command.Restore;
using Model.Link;
using Repository.CourseStudent;

namespace CourseService.CourseTermStudent.CourseTermStudentRestore.Command
{
    public class CourseTermStudentRestoreService : BaseRestoreCommand<CourseStudentDbo, ICourseStudentRepository>, ICourseTermStudentRestoreService
    {
        public CourseTermStudentRestoreService(ICourseStudentRepository repository)
            : base(repository) { }
    }
}
