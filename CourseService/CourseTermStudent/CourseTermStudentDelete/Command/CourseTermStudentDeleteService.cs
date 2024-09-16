using Core.Base.Command.Delete;
using Model.Link;
using Repository.CourseStudent;

namespace CourseService.CourseTermStudent.CourseTermStudentDelete.Command
{
    public class CourseTermStudentDeleteService : BaseDeleteCommand<CourseStudentDbo, ICourseStudentRepository>, ICourseTermStudentDeleteService
    {
        public CourseTermStudentDeleteService(ICourseStudentRepository repository)
            : base(repository) { }
    }
}
