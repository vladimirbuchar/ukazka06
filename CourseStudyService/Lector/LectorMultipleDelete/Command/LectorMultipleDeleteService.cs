using Core.Base.Command.MultipleDelete;
using Model.Link;
using Repository.CourseLector;

namespace CourseStudyService.Lector.LectorMultipleDelete.Command
{
    public class LectorMultipleDeleteService : BaseMultipleDeleteCommand<CourseLectorDbo, ICourseLectorRepository>, ILectorMultipleDeleteService
    {
        public LectorMultipleDeleteService(ICourseLectorRepository repository)
            : base(repository) { }
    }
}
