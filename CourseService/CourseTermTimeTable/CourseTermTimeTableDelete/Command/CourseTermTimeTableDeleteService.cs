using Core.Base.Command.Delete;
using Model.Edu.CourseTermDate;
using Repository.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableDelete.Command
{
    public class CourseTermTimeTableDeleteService : BaseDeleteCommand<CourseTermDateDbo, ICourseTermDateRepository>, ICourseTermTimeTableDeleteService
    {
        public CourseTermTimeTableDeleteService(ICourseTermDateRepository repository)
            : base(repository) { }
    }
}
