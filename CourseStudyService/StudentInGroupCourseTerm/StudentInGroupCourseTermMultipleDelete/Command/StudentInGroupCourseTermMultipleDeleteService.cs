using Core.Base.Command.MultipleDelete;
using Model.Link;
using Repository.StudentInGroupCourseTerm;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermMultipleDelete.Command
{
    public class StudentInGroupCourseTermMultipleDeleteService
        : BaseMultipleDeleteCommand<StudentInGroupCourseTermDbo, IStudentInGroupCourseTermRepository>,
            IStudentInGroupCourseTermMultipleDeleteService
    {
        public StudentInGroupCourseTermMultipleDeleteService(IStudentInGroupCourseTermRepository repository)
            : base(repository) { }
    }
}
