using Core.Base.Command.Restore;
using Model.Edu.CourseTermDate;
using Repository.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableRestore.Command
{
    public class CourseTermTimeTableRestoreService
        : BaseRestoreCommand<CourseTermDateDbo, ICourseTermDateRepository>,
            ICourseTermTimeTableRestoreService
    {
        public CourseTermTimeTableRestoreService(ICourseTermDateRepository repository)
            : base(repository) { }
    }
}
